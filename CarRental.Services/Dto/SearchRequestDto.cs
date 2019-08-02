using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Services.Dto
{
    public class SearchRequestDto 
    {
        public int? CarId { get; set; } = null;
        public string CarBrand { get; set; } = null;
        public int? CarYear { get; set; } = null;
        public int? MaxPrice { get; set; } = null;
        public int? MinPrice { get; set; } = null;
        public int? MinKm { get; set; } = null;
        public int? MaxKm { get; set; } = null;
        public int? CarStyle { get; set; } = null;
        public string CarModel { get; set; } = null;
        public string CarLocation { get; set; } = null;
        public string CarColor { get; set; } = null;
        public int? CarKm { get; set; } = null;
        public int? CarFuelTypes { get; set; } = null;
        public bool? IsManual { get; set; } = null;
        public DateTime? StartDate { get; set; } = null;
        public DateTime? EndDate { get; set; } = null;
   
    }
}
