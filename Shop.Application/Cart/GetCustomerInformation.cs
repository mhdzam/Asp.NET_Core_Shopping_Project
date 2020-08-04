﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
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
            var Response = JsonConvert.DeserializeObject<Request>(StringObject);
            return Response;


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
