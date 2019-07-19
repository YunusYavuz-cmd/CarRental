using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Services.Dto
{
    public class BookCustomerDto
    {
        public DateTime RentStartDate { get; set; }
        public DateTime RentEndDate { get; set; }
        public int ReferenceNumber { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerName { get; set; }
        public int CustomerAge { get; set; }
        public int CustomerLicenseAge { get; set; }
        public int carId { get; set; }
    }
}
