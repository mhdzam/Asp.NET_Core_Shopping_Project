using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Models
{
   public class Order
    {
        public int Id { get; set; }
        public string OrderRef { get; set; }
        public string StripeRef { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string Address1 { get; set; }
        public string Address2 { set; get; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        public ICollection<OrderStuck> OrderStucks { get; set; }
    }
}
