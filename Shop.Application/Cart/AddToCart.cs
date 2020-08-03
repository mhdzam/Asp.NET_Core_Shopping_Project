using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
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
            var cartPRoduct = new CartProduct() { 
             Qty = request.Qty,
             StockId = request.StockId
            };
            var StringObject = JsonConvert.SerializeObject(cartPRoduct);
            //TODO: appending the card
            _session.SetString("cart",StringObject);
        }

        public class Request
        {
            public int StockId { get; set; }
            public int Qty { set; get; }
        }
    }
}
