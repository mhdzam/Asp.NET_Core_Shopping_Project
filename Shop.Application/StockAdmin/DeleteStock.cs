using Shop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.StockAdmin
{
   public class DeleteStock
    {
        private ApplicationDbContext _ctx;

        public DeleteStock(ApplicationDbContext dbx)
        {
            _ctx = dbx;
        }
        public async Task<bool> Do(int Id)
        {
            var stock = _ctx.Stock.FirstOrDefault(X => X.Id == Id);

            _ctx.Stock.Remove(stock);

          await  _ctx.SaveChangesAsync();


            return true;
        }

        public class Request { }
        public class Response { }
    }
}
