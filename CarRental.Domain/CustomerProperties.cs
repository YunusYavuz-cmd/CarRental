using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Domain
{
  
    public class CustomerProperties : DomainBase
    {
        public int CustomerId { get; set; }
        public CustomerPropertyType Type { get; set; }
        public int TypeId { get; set; }
        public string Value { get; set; }
    }

    public enum CustomerPropertyType
    {
        CustomerAge =1,
        CustomerLicenseAge=2,
        CustomerTaxDep =3,
        CustomerTaxNum =4,
    }
}