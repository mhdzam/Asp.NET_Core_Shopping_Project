using Microsoft.EntityFrameworkCore;
using Shop.Database;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Application.StockAdmin
{
   public class GetStock
    {
        private ApplicationDbContext _ctx;

        public GetStock(ApplicationDbContext dbx)
        {
            _ctx = dbx;
        }

        public IEnumerable<productViewModel> Do()
        {
            var stock = _ctx.Products
                .Include(X => X.Stock)
                .Select(X => new productViewModel { Description = X.Description, Id = X.Id, stock = X.Stock.Select(y => new stockViewModel { Description = y.Description, Id = y.Id, Qty = y.Qty }) })
                .ToList();
         
            return stock;
        }
    }


    public class stockViewModel
    {

        public int Id { set; get; }
        public string Description { get; set; }
        public int Qty { get; set; }
    }

    public class productViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public IEnumerable<stockViewModel> stock { set; get; }
    }

}
