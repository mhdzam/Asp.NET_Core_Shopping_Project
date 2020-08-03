using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;


namespace Shop.Application.Cart
{
   public class AddToCart
    {
        private ISession _session;

        public AddToCart(ISession session)
        {
            _session = session;
        }

        public void Do(Request request)
        {
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
        }

        public class Request
        {
            public int StockId { get; set; }
            public int Qty { set; get; }
        }
    }
}
