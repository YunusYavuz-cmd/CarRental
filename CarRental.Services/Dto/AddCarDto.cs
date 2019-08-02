using CarRental.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Services.Dto
{
   public class AddCarDto
    {

        [Required] public string CarBrand { get; set; }
        [Required] public string CarModel { get; set; }
        [Required] public string CarColor { get; set; }
        [Required] public string CarLocation { get; set; }
        [Required] public int CarYear { get; set; }
        [Required] public int CarKm { get; set; }
        [Required] public int CarFuelTypes { get; set; }
        [Required] public bool IsManual { get; set; }
        [Required] public int CarStyle { get; set; }
        public int? LocationId { get; set; } 
        public List<Book> Books { get; set; } = null;
        public List<PriceTable> PriceTables { get; set; } = null;
    }
}
