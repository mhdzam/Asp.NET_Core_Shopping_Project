using Shop.Database;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Orders
{
   public class CreateOrder
    {
        private ApplicationDbContext _ctx;

        public CreateOrder(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public class Request
        {
            public string StripeReference { get; set; }
            public string FirstName { get; set;}
            public string LastName { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public string Address1 { get; set; }
            public string Address2 { set; get; }
            public string City { get; set; }
            public string PostalCode { get; set; }
            public List<Stuck> Stocks { get; set; }
        }

        public class Stuck
        {
            public int StuckId { get; set; }
            public int Qty { get; set; }
        }
        public async Task<bool> Do(Request request)
        {

            var order = new Order
            { OrderRef = CreateOrderReference(),
                Address1 = request.Address1,
                Address2 = request.Address2,
                City = request.City,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                PostalCode = request.PostalCode,
                 StripeRef = request.StripeReference,
                 OrderStucks = request.Stocks.Select(X => new OrderStuck
                {
                    Qty = X.Qty,
                     StockId = X.StuckId
                }).ToList()
            };

            _ctx.Orders.Add(order);

         return  await _ctx.SaveChangesAsync() > 0;

            
        }

        public string CreateOrderReference()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz123456789";
            var result = new char[12];

            var random = new Random();
            // generate Ordrref that doesn't exist before !
            do{
                for (int i = 0; i < result.Length; i++)
                    result[i] = chars[random.Next(chars.Length)];
            } while (_ctx.Orders.Any(X => X.OrderRef == new string(result)));
            return new string(result);
        }
    }
}
