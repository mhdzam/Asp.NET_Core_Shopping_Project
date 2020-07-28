using Shop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Application.ProductsAdmin
{
   public class GetProducts
    {
        private ApplicationDbContext _ctx;

        public GetProducts(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<ProductViewModel> Do() =>
        
            _ctx.Products.ToList().Select(X => new ProductViewModel() {Id=X.Id,Name= X.Name, Value = X.Value
             });

        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        //    public string Description { get; set; }
            public decimal Value { get; set; }
        }
    }


}
