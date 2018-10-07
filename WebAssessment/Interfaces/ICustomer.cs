using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAssessment.Interfaces
{
    interface ICustomer
    {
        string Name { get; set; }
        string Email { get; set; }
        string Address { get; set; }
    }
}
