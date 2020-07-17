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

        public async Task Do(ProductViewModel product)
        {
            _ctx.Products.Update(new Domain.Models.Product() { Description = product.Description, Id=product.Id, Name=product.Name, Value = product.Value});
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
