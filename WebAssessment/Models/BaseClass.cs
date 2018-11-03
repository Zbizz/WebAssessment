using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Every class must inherit from this to keep things standardised

namespace WebAssessment.Models
{
    public class BaseClass
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
