using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Domain
{
  
    public class CustomerProperties : DomainBase
    {
        public int TypeId { get; set; }
        public int Value { get; set; }
    }

    public enum CustomerPropertyType
    {
        CustomerAge =1,
        CustomerLicenseAge=2
    }
}