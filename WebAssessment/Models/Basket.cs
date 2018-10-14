using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAssessment.Interfaces;

namespace WebAssessment.Models
{
    public class Basket : BaseClass, IBasket
    {
        public List<BasketItem> BasketItems { get ; set; }
    }
}