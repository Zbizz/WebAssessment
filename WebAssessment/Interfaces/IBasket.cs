using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAssessment.Models;

namespace WebAssessment.Interfaces
{
    interface IBasket
    {
        List<BasketItem> BasketItems { get; set; }
    }
}
