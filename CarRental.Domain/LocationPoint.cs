using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Domain
{
    public class LocationPoint: DomainBase
    {
        public int LocationId { get; set; }
        public string LocationPointName { get; set; }
        public virtual Location Location { get; set; }
    }
}
