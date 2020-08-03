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
   public class GetCart
    {
        private ApplicationDbContext _dbx;
        private ISession _session;

        public GetCart(ISession session, ApplicationDbContext dbx)
        {
            _dbx = dbx;
            _session = session;
        }

        public Response Do()
        {
            // account for multiple items in the cart
            var StringObject = _session.GetString("cart");

            var cartRoduct =  JsonConvert.DeserializeObject<CartProduct>(StringObject);
            //TODO: appending the card

            var response = _dbx.Stock
                .Include(X => X.Product)
                .Where(X => X.Id == cartRoduct.StockId)
                .Select(X => new Response()
                {
                    Name = X.Product.Name,
                    Qty = cartRoduct.Qty,
                    Value = $"{X.Product.Value.ToString("N2")}",
                    StockId = X.Id
                })
                .FirstOrDefault();

            return response;
        }

        public class Response
        {
            public string Name { get; set; }
            public string Value { get; set; }
            public int Qty { set; get; }
            public int StockId { set; get; }
        }
    }
}
