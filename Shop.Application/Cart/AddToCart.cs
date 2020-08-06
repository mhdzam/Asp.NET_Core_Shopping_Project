using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using Shop.Database;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Cart
{
   public class AddToCart
    {
        private ApplicationDbContext _ctx;
        private ISession _session;

        public AddToCart(ISession session, ApplicationDbContext ctx)
        {
            _ctx = ctx;
            _session = session;
        }

        public async Task<bool> Do(Request request)
        {
            var StockToHold = _ctx.Stock.Where(X => X.Id == request.StockId).FirstOrDefault();

            if(StockToHold.Qty < request.Qty)
            {
                // return not enough Items in the stock
                return false;
            }

            _ctx.StocskOnHold.Add(new StockOnHold
            {
                StockId = StockToHold.Id,
                Qty = request.Qty,
                ExpiryDate = DateTime.Now.AddMinutes(20) // it will holded for just 20 minutes !
            });

            StockToHold.Qty -= request.Qty;   // subtracting the holded qty !

            await _ctx.SaveChangesAsync();

            var CartList = new List<CartProduct>();
            var StringObject = _session.GetString("cart");

            if(!string.IsNullOrEmpty(StringObject))
            {
                CartList = JsonConvert.DeserializeObject<List<CartProduct>>(StringObject);
            }

          if(CartList.Any(X => X.StockId == request.StockId))
            {
                CartList.Find(x => x.StockId == request.StockId).Qty += request.Qty;
            }
          else
            {
                CartList.Add(new CartProduct()
                {
                    Qty = request.Qty,
                    StockId = request.StockId
                });
            }

           
             StringObject = JsonConvert.SerializeObject(CartList);
       
            _session.SetString("cart",StringObject);

            return true;
        }

        public class Request
        {
            public int StockId { get; set; }
            public int Qty { set; get; }
        }
    }
}
