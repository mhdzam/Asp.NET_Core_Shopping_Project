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

        public async Task<response> Do(Request Request)
        {
          var product =  new Product() { Name = Request.Name, Description = Request.Description, Value = decimal.Parse(Request.Value) };
            _context.Add(product);
           await _context.SaveChangesAsync();

            return new response()
            {
                Id = product.Id,
                Description = product.Description,
                Name = product.Name,
                Value = product.Value
            };
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
