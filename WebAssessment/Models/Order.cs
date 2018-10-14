using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAssessment.Interfaces;

namespace WebAssessment.Models
{
    public class Order : BaseClass, IOrder
    {
        public DateTime OrderDate { get; set; }
        public int OrderStatus { get; set; }
        public int CustomerId { get; set; }
        public List<BasketItem> Basket { get; set; }
        public decimal FullPrice { get; set; }
        public decimal PriceAfterDiscount { get; set; }
        public bool DiscountApplied { get; set; }
        

    }
}