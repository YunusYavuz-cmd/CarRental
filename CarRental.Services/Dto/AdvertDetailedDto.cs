using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Services.Dto
{
    public class AdvertDetailedDto : MiniAdvertDto
    {
        public string CarColor { get; set; }
        public int CarKm { get; set; }
        public CarRental.Domain.Car.CarFuelTypes CarFuelTypes { get; set; }
        public bool IsManual { get; set; }
        public int ClickedNum { get; set; }
    }
}
