using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Domain
{
   public class Customer : DomainBase
    {
        public string CustomerEmail { get; set; }
        public int CustomerPhoneNumber { get; set; }
        public int CustomerValue { get; set; }
        public virtual List<CustomerProperties> CustomerProperties { get; set; }
    }

    public enum CustomerType
    {
        individual=1,
        company=2

    }
}
