using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Cart;
using Shop.Database;

namespace ShopUI.Pages.CheckOut
{
    public class CustomerInformationModel : PageModel
    {
        public IActionResult OnGet()
        {
            var information = new GetCustomerInformation(HttpContext.Session).Do();
            if(information == null)
            {
                return Page();
            }
            else
            {
                return RedirectToPage("/CheckOut/Payment");
            }
       
        }
        [BindProperty]
        public AddCustomerInformation.Request CustomerInformation { get; set; }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            new AddCustomerInformation(HttpContext.Session).Do(CustomerInformation);

            return RedirectToPage("Payment");
        }
    }
}