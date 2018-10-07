using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAssessment.Interfaces
{
    interface IOrder
    {
        DateTime OrderDate { get; set; }
        int OrderStatus { get; set; }
        int CustomerId { get; set; }
        List<IBasketItem> Basket { get; set; }
    }
}
