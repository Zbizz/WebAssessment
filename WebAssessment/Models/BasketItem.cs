using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebAssessment.Interfaces;

namespace WebAssessment.Models
{
    public class BasketItem : BaseClass, IBasketItem
    {
        public int ProductId { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}