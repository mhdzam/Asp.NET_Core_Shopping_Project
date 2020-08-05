using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Cart
{
   public class GetCustomerInformation
    {
        private ISession _session;

        public GetCustomerInformation(ISession session)
        {
            _session = session;
        }

        public Request Do()
        {

           var StringObject =  _session.GetString("Customer-Info");
            if(String.IsNullOrEmpty(StringObject))
            {
                return null;
            }
            var customerinformation = JsonConvert.DeserializeObject<CustomerInformation>(StringObject);
            return new Request
            {
                Address1 = customerinformation.Address1,
                Address2 = customerinformation.Address2,
                Email = customerinformation.Email,
                City = customerinformation.City,
                FirstName = customerinformation.FirstName,
                LastName = customerinformation.LastName,
                PhoneNumber = customerinformation.PhoneNumber,
                PostalCode = customerinformation.PostalCode
            };


        }

        public class Request
        {
            public string FirstName { get; set; }
       
            public string LastName { get; set; }
          
            public string Email { get; set; }
          
            public string PhoneNumber { get; set; }
     
            public string Address1 { get; set; }
          
            public string Address2 { set; get; }
        
            public string City { get; set; }
         
            public string PostalCode { get; set; }
        }
    }
}
