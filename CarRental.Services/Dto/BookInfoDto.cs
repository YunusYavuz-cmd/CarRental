using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Services.Dto
{
    public class BookInfoDto
    {
        public DateTime RentStartDate { get; set; }
        public DateTime RentEndDate { get; set; }
        public string CustomerName { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public string CarColor { get; set; }
        public string CarLocation { get; set; }
        public int CarYear { get; set; }
        public bool IsManual { get; set; } 
    }
}
