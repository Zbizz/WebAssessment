using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAssessment.Interfaces
{
    interface IDiscount
    {
        decimal Discount(IOrder order);
    }
}
