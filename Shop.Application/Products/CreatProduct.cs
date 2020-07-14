using Shop.Database;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Shop.Application.Products
{
    class CreatProduct
    {
        private ApplicationDbContext _context;

        public CreatProduct(ApplicationDbContext Context)
        {
            _context = Context;
        }

        public void Do(Product _product)
        {
            _context.Add(_product);
            _context.SaveChanges();
        }
    }
}
