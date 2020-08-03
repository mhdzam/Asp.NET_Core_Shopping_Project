using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Cart;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Shop.Database;

namespace ShopUI.Pages
{
    public class CartModel : PageModel
    {
      
        private ApplicationDbContext _ctx;

        public GetCart.Response cart { get; set; }

        public CartModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IActionResult OnGet()
        {
            cart = new GetCart(HttpContext.Session,_ctx).Do();

            return Page();
        }
    }
}