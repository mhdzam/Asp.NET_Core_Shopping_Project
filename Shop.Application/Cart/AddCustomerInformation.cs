using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Shop.Application.Cart
{
   public class AddCustomerInformation
    {
        private ISession _session;

        public AddCustomerInformation(ISession session)
        {
            _session = session;
        }

        public void Do(Request request)
        {
          var customerinformation = new CustomerInformation
            {
                Address1 = request.Address1,
                Address2 = request.Address2,
                Email = request.Email,
                City = request.City,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                PostalCode = request.PostalCode
            };

            var StringObject = JsonConvert.SerializeObject(customerinformation);

            _session.SetString("Customer-Info", StringObject);
        }

        public class Request
        {
            [Required]
            public string FirstName { get; set; }
            [Required]
            public string LastName { get; set; }
            [Required]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }
            [Required]
            [DataType(DataType.PhoneNumber)]
            public string PhoneNumber { get; set; }
            [Required]
            public string Address1 { get; set; }
            public string Address2 { set; get; }
            [Required]
            public string City { get; set; }
            [Required]
            public string PostalCode { get; set; }
        }
    }
}
