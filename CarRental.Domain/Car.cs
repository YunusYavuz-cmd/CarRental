using System;
using System.Collections.Generic;
using System.Text;

 namespace CarRental.Domain
{
    
    public class Car : DomainBase
    {
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public string CarColor { get; set; }
        public string CarLocation { get; set; }
        public int CarYear { get; set; }
        public int CarKm { get; set; }
        public CarFuelTypes CarFuelType { get; set; }
        public bool IsManual { get; set; }
        public CarStyles CarStyle { get; set; }
        public int LocationId { get; set; }
        public virtual IList<Book> Books { get; set; }
        public virtual IList<PriceTable> PriceTables { get; set; }
        public virtual Location Location { get; set; }
        public enum CarFuelTypes
        {
            Benzin = 1,
            Dizel = 2,
            LPG = 3
        }
        public enum CarStyles {
            otomobil=1,
            araziPick=2,
            minivan=3,
            klasikArac=4
        }
    }
}