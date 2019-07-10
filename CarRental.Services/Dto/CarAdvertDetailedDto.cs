using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Services.Dto
{
    public class CarAdvertDetailedDto : MiniAdvertDto
    {

        public string CarColor { get; set; }
        public int CarKm { get; set; }
        public int CarFuelTypes { get; set; } //if 1 benzin 2 dizel 3 lpg
        public bool IsManual { get; set; }

        //public int AvaibleCarNum {get; set;}

    }
}
