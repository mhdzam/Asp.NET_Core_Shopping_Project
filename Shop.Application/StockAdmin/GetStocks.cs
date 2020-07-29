using Shop.Database;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Application.StockAdmin
{
    class GetStocks
    {
        private ApplicationDbContext _ctx;

        public GetStocks(ApplicationDbContext dbx)
        {
            _ctx = dbx;
        }

        public IEnumerable<stockViewModel> Do(int productId)
        {
            var stocks = _ctx.Stock.Where(X => X.ProductId == productId).Select(X => new stockViewModel { Description =X.Description, Id = X.Id, Qty = X.Qty }).ToList();


            return stocks;
        }
    }


    public class stockViewModel
    {

        public int Id { set; get; }
        public string Description { get; set; }
        public int Qty { get; set; }
    }

}
