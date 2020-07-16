using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Shop.Application.Products;
using Shop.Database;

namespace ShopUI.Pages
{
    public class IndexModel : PageModel
    {
        public ApplicationDbContext _ctx { get; set; }

        public IndexModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        private readonly ILogger<IndexModel> _logger;

        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}

        [BindProperty]
        public ProductViewModel product { get; set; }
        public class ProductViewModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }
        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        {
           await new CreatProduct(_ctx).Do(product.Description, product.Name, product.Value);
            return RedirectToPage("Index");
        }
    }
}
