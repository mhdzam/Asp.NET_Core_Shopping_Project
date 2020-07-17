using Shop.Database;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.ProductsAdmin
{
  public  class CreatProduct
    {
        private ApplicationDbContext _context;

        public CreatProduct(ApplicationDbContext Context)
        {
            _context = Context;
        }

        public async Task Do(ProductViewModel _product)
        {
            _context.Add(new Product() { Name= _product.Name, Description= _product.Description, Value = _product.Value });
           await _context.SaveChangesAsync();
        }

        public class ProductViewModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }
        }
    }


 
}
