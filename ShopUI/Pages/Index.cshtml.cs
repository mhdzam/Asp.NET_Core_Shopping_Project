using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Shop.Application.GetProducts;
using Shop.Application.Products;
using Shop.Database;

namespace ShopUI.Pages
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _ctx { get; set; }

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
        public Shop.Application.CreateProducts.ProductViewModel product { get; set; }

        public IEnumerable<ProductViewModel> products { set; get; }

        public void OnGet()
        {
            products = new Shop.Application.GetProducts.GetProducts(_ctx).Do();
        }
        public async Task<IActionResult> OnPost()
        {
           await new Shop.Application.CreateProducts.CreatProduct(_ctx).Do(product);
            return RedirectToPage("Index");
        }
    }
}
