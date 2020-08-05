using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Shop.Database;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Application.Cart
{
   public class GetOrder
    {
        private ApplicationDbContext _dbx;
        private ISession _session;

        public GetOrder(ISession session, ApplicationDbContext dbx)
        {
            _dbx = dbx;
            _session = session;
        }

        public Response Do()
        {
            // account for multiple items in the cart
            var Cart = _session.GetString("cart");

           
            var cartList = JsonConvert.DeserializeObject<List<CartProduct>>(Cart);

            var ListOfProducts = _dbx.Stock
                .Include(X => X.Product).ToList()
                .Where(X => cartList.Any(y => y.StockId == X.Id))
                .Select(X => new Product { 
                 ProductId = X.ProductId,
                 StockId = X.Id,
                  Value = (int) (X.Product.Value * 100),
                  Qty = cartList.FirstOrDefault(y => y.StockId == X.Id).Qty
                })
                .ToList();
            var CutsomerInformationString = _session.GetString("Customer-Info");
            var customerInformation = JsonConvert.DeserializeObject<Domain.Models.CustomerInformation>(CutsomerInformationString);

            return new Response
            {
                 PRoducts = ListOfProducts,
                  customerinformation = new Domain.Models.CustomerInformation
                  {
                      Address1 = customerInformation.Address1,
                      Address2 = customerInformation.Address2,
                      Email = customerInformation.Email,
                      City = customerInformation.City,
                      FirstName = customerInformation.FirstName,
                      LastName = customerInformation.LastName,
                      PhoneNumber = customerInformation.PhoneNumber,
                      PostalCode = customerInformation.PostalCode
                  }
            };
        }

        public class Response
        {
            public IEnumerable<Product> PRoducts { get; set; }
            public Domain.Models.CustomerInformation customerinformation { get; set; }

            public int GetTotalCharge() => PRoducts.Sum(X => X.Value * X.Qty);
        }

        public class Product
        {
            public int Qty { set; get; }
            public int ProductId { get; set; }
            public int StockId { set; get; }
            public int Value { get; set; }
        }

        public class CustomerInformation
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Email { get; set; }

            public string PhoneNumber { get; set; }

            public string Address1 { get; set; }

            public string Address2 { set; get; }

            public string City { get; set; }

            public string PostalCode { get; set; }
        }
    }
}
