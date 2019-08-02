using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Domain
{
    public class Book : DomainBase
    {
        public DateTime RentStartDate { get; set; }
        public DateTime RentEndDate { get; set; }
        public int BeforeKm { get; set; }
        public int AfterKm { get; set; }
        public string ReferenceNumber { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public string LocationInfo { get; set; }
        public virtual Car Car { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
