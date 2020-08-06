using Shop.Database;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.StockAdmin
{
   public class UpdateStock
    {
        private ApplicationDbContext _ctx;

        public UpdateStock(ApplicationDbContext dbx)
        {
            _ctx = dbx;
        }
        public async Task<Response> Do(Request request)
        {
            List<Stock> stocks = new List<Stock>();
            foreach(var stock in request.stock)
            {
                stocks.Add(new Stock() { 
                 Description = stock.Description,
                  ProductId = stock.ProductId,
                   Qty = stock.Qty,
                    Id = stock.Id
                });
            }

            _ctx.UpdateRange(stocks);
           await _ctx.SaveChangesAsync();
            return new Response {
                stock = request.stock
            };
        }



        public class stockViewModel
        {

            public int Id { set; get; }
            public string Description { get; set; }
            public int Qty { get; set; }
            public int ProductId { get; set; }
        }

        public class Request
        {
            public IEnumerable<Stock> stock { set; get; }
        }


        public class Response
        {
            public IEnumerable<Stock> stock { set; get; }
        }

    }
}
