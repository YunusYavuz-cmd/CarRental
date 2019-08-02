using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Domain
{
    public class Location: DomainBase
    {
        public string CityLocation { get; set; }
        public virtual IList<Car> Cars { get; set; }
        public virtual IList<LocationPoint> LocationPoints { get;set; }
    }
}
