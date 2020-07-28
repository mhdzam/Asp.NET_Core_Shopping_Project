using Shop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.ProductsAdmin
{

  public class UpdateProduct
    {
        private ApplicationDbContext _ctx;

        public UpdateProduct(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<response> Do(Request request)
        {
            var _product = _ctx.Products.FirstOrDefault(X => X.Id == request.Id);
            _product.Name = request.Name;
            _product.Value =request.Value;
            _product.Description = request.Description;
            await _ctx.SaveChangesAsync();
            return new response() { 
                  Id = _product.Id,
             Description = _product.Description,
             Value = _product.Value,
             Name = _product.Name
             
            };
        }

        public class Request
        {
            public int Id { set; get; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }
        }

        public class response
        {

            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }
        }
    }
}
