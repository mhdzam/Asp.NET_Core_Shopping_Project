using Shop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.ProductsAdmin
{
  public  class DeleteProduct
    {
        private ApplicationDbContext _ctx;

        public DeleteProduct(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task Do (int Id)
        {
            var product = _ctx.Products.FirstOrDefault(X => X.Id == Id);
            _ctx.Products.Remove(product);
            await _ctx.SaveChangesAsync();
        }

        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }
        }
    }
}
