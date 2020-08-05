using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Cart;
using Shop.Database;

namespace ShopUI.Pages.CheckOut
{
    public class CustomerInformationModel : PageModel
    {
        [Obsolete]
        private IHostingEnvironment _env;

        [Obsolete]
        public CustomerInformationModel(IHostingEnvironment env)
        {
            _env = env;
        }

        [Obsolete]
        public IActionResult OnGet()
        {
            var information = new GetCustomerInformation(HttpContext.Session).Do();

            if (_env.IsDevelopment())
            {
                CustomerInformation = new AddCustomerInformation.Request
                {
                    FirstName = "Mhd",
                    LastName = "Zamel",
                    Address1 = "Dubai",
                    Address2 = "Ajman",
                    City = "Damascus",
                    Email = "intell_progr_1991@hotmail.com",
                    PhoneNumber = "0505838490",
                    PostalCode = "00000"
                };
            }
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