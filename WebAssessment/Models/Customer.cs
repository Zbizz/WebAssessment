using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAssessment.Interfaces;

namespace WebAssessment.Models
{
    public class Customer : BaseClass, ICustomer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}