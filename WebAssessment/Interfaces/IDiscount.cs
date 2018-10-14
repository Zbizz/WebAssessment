using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAssessment.Interfaces
{
    interface IDiscount
    {
        string DiscountCode { get; set; }
        int PercentageOff { get; set; }
        decimal Discount(IOrder order);
    }
}
