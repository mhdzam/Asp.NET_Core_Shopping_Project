using Shop.Database;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.StockAdmin
{
    class CreateStock
    {
        private ApplicationDbContext _ctx;

        public CreateStock(ApplicationDbContext dbx)
        {
            _ctx = dbx;
        }
        public async Task<Response> Do( Request request)
        {
            var stock = new Stock()
            {
                Description = request.Description,
                ProductId = request.ProductId,
                Qty = request.Qty
            };
            _ctx.Stock.Add(stock);
          await  _ctx.SaveChangesAsync();

            
            return new Response() { Description = stock.Description, Id = stock.Id, Qty = stock.Qty};
        }

        public class Request
        {

            public string Description { get; set; }
            public int Qty { get; set; }
            public int ProductId { get; set; }
        }


        public class Response
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public int Qty { get; set; }
        }
    }
}
