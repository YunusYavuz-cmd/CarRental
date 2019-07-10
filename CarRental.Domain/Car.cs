using System;
using System.Collections.Generic;
using System.Text;

 namespace CarRental.Domain
{
    public enum CarFuelTypes {
        Benzin=1,
        Dizel=2,
        LPG=3
    }
    public class Car : DomainBase
    {
        public int CarId { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public string CarColor { get; set; }
        public string CarLocation { get; set; }
        public int CarYear { get; set; }
        public int CarKm { get; set; }
        public CarFuelTypes CarFuelTypes { get; set; }
        public bool IsManual { get; set; }
      
    }
}
