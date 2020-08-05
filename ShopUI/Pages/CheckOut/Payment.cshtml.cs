using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Shop.Application.Cart;
using Stripe;

namespace ShopUI.Pages.CheckOut
{
    public class PaymentModel : PageModel
    {
       
        public PaymentModel(IConfiguration config)
        {
            PublickKey = config["Stripe:PublicKey"].ToString();
        }

        public string PublickKey { get; }

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

        public IActionResult OnPost(string stripeEmail, string stripeToken)
        {

            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken
            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = 500, // get cart details from session and make a total ammount that must paied !
                Description = "Sample Charge",
                Currency = "usd",
                Customer = customer.Id
            });

            return Page();  // View();


            // return RedirectToPage("/Index");
        }

        public IActionResult Index()
        {
            return Page();
        }

        public IActionResult Error()
        {
            return Page();
        }
    }
}