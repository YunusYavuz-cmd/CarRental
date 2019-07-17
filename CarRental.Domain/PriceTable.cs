using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Domain
{
    public class PriceTable : DomainBase
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CarPrice { get; set; }
    }
}
