﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests.Customers
{
    public class CreateCustomerRequest
    {
        public int UserId { get; set; }
        public string CompanyName { get; set; }
    }
}
