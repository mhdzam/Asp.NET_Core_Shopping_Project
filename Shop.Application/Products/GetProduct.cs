using Microsoft.EntityFrameworkCore;
using Shop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Products
{
   public class GetProduct
    {
        private ApplicationDbContext _ctx;

        public GetProduct(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<ProductViewModel> Do(string name)
        {

          var stocksOnHold = _ctx.StocskOnHold.Where(X => X.ExpiryDate < DateTime.Now).ToList();

            if(stocksOnHold.Count > 0)
            {
                var stockToReturn = _ctx.Stock.AsEnumerable().Where(X => stocksOnHold.Any(Y => Y.StockId == X.Id)).ToList();
                foreach(var stock in stockToReturn)
                {
                    stock.Qty += stocksOnHold.FirstOrDefault(X => X.StockId == stock.Id).Qty;
                }
                _ctx.StocskOnHold.RemoveRange(stocksOnHold);
                await _ctx.SaveChangesAsync();
            }

         return   _ctx.Products.Where(X => X.Name == name)
            .Include(X => X.Stock)
            .Select(X => new ProductViewModel()
            {
                Id = X.Id,
                Name = X.Name,
                Value = X.Value,
                Stock = X.Stock.Select(y => new StockViewModel
                {
                    Description = y.Description,
                    Id = y.Id,
                    InStock = y.Qty > 0
                })
            })
            .FirstOrDefault();
        }

        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            //    public string Description { get; set; }
            public decimal Value { get; set; }

            public IEnumerable<StockViewModel> Stock { get; set; }
        }

        public class StockViewModel
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public bool InStock { get; set; }
        }
    }
}
