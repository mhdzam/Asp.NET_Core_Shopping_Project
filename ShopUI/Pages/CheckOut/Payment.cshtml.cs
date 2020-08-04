using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Cart;

namespace ShopUI.Pages.CheckOut
{
    public class PaymentModel : PageModel
    {
        public IActionResult OnGet()
        {
            var information = new GetCustomerInformation(HttpContext.Session).Do();
            if (information == null)
            {
                return RedirectToPage("/CheckOt/CustomerInformation");
            }
            else
            {
                return Page();
            }


        }
    }
}