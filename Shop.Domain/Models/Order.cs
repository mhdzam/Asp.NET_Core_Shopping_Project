using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Models
{
   public class Order
    {
        public int Id { get; set; }
        public string OrderRef { get; set; }
        public string Address1 { get; set; }
        public string Address2 { set; get; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}
