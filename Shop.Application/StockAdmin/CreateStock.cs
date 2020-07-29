using Shop.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.StockAdmin
{
    class CreateStock
    {
        private ApplicationDbContext _ctx;

        public CreateStock(ApplicationDbContext dbx)
        {
            _ctx = dbx;
        }
    }
}
