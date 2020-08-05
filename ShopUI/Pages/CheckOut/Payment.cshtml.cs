using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Shop.Application.Cart;
using Shop.Database;
using Stripe;

namespace ShopUI.Pages.CheckOut
{
    public class PaymentModel : PageModel
    {
               private ApplicationDbContext _ctx;

        public string PublickKey { get; }
        public int TotalPayment { set; get; }
        public PaymentModel(IConfiguration config, ApplicationDbContext ctx)
        {
            _ctx = ctx;
            PublickKey = config["Stripe:PublicKey"].ToString();
        }



        public IActionResult OnGet()
        {
            var CartOrder = new GetOrder(HttpContext.Session, _ctx).Do();
            TotalPayment = CartOrder.GetTotalCharge();

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

            var CartOrder = new GetOrder(HttpContext.Session, _ctx).Do();
            TotalPayment = CartOrder.GetTotalCharge();

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = TotalPayment,
                Description = "Shop Pruchase",
                Currency = "gbp",
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