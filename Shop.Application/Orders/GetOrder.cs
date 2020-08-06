using Microsoft.EntityFrameworkCore;
using Shop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Application.Orders
{
   public class GetOrder
    {
        private ApplicationDbContext _ctx;

        public GetOrder(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public class Respone
        {
            public string OrderRef { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public string Address1 { get; set; }
            public string Address2 { set; get; }
            public string City { get; set; }
            public string PostalCode { get; set; }

            public IEnumerable<Product> Products { get; set; }

            public string TotalValue { get; set; }
        }

        public class Product
        {
            public string Name { get; set; }
            //    public string Description { get; set; }
            public string Value { get; set; }

            public string Description { get; set; }
            public int Qty { get; set; }

            public string StockDescription { get; set; }
        }

        public Respone Do(string Reference) =>
                _ctx.Orders.Where(X => X.OrderRef == Reference)
                .Include(X => X.OrderStucks)
                .ThenInclude(X => X.stock)
                .ThenInclude(X => X.Product)
                .Select(X => new Respone
                {
                    OrderRef = X.OrderRef,
                    Address1 = X.Address1,
                    Address2 = X.Address2,
                    City = X.City,
                    Email = X.Email,
                    FirstName = X.FirstName,
                    LastName = X.LastName,
                    PhoneNumber = X.PhoneNumber,
                    PostalCode = X.PostalCode,
                    Products = X.OrderStucks.Select(Y => new Product
                    {
                        Name = Y.stock.Product.Name,
                        Description = Y.stock.Product.Description,
                        Value = $"$ {Y.stock.Product.Value.ToString("N2")}",
                        Qty = Y.Qty,
                        StockDescription = Y.stock.Description

                    }),
                     TotalValue = X.OrderStucks.Sum(Y => Y.stock.Product.Value).ToString("N2")
                })
                .FirstOrDefault();
        
    }
}
