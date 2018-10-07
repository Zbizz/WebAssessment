using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAssessment.Interfaces
{
    interface IBasketItem
    {
        int ProductId { get; set; }
        int OrderId { get; set; }
        int Quantity { get; set; }
    }
}
