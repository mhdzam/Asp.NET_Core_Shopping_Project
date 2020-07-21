using Shop.Database;
using System;
using System.Collections.Generic;
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

        public async Task<bool> Do(Request request)
        {
            _ctx.Products.Update(new Domain.Models.Product() { Description = request.Description, Name= request.Name});
            await _ctx.SaveChangesAsync();
            return true;
        }

        public class Request
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Value { get; set; }
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
