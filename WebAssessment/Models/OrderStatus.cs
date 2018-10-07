using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAssessment.Interfaces;

namespace WebAssessment.Models
{
    public class OrderStatus : BaseClass, IOrderStatus
    {
        public string Description { get; set; }
    }
}