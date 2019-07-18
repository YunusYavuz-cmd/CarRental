using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Domain
{
   public class Customer : DomainBase
    {
        public string CustomerEmail { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerName { get; set; }
        public virtual List<CustomerProperties> CustomerProperties { get; set; }
    }

}
