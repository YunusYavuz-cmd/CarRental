using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Services.Dto
{
    public class AdvertDetailedDto : MiniAdvertDto
    {

        public string CarColor { get; set; }
        public int CarKm { get; set; }
        public int CarFuelTypes { get; set; }   
        public bool IsManual { get; set; }

    }
}
