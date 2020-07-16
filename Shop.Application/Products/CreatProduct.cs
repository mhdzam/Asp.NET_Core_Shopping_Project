using Shop.Database;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Products
{
  public  class CreatProduct
    {
        private ApplicationDbContext _context;

        public CreatProduct(ApplicationDbContext Context)
        {
            _context = Context;
        }

        public async Task Do(string _Description, string _Name, decimal _Value)
        {
            _context.Add(new Product() { Name=_Name, Description= _Description , Value = _Value});
           await _context.SaveChangesAsync();
        }
    }
}
