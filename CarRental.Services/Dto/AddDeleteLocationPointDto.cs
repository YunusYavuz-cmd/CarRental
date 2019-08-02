using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarRental.Services.Dto
{
   public class AddDeleteLocationPointDto
    {
        [Required]public string CityLocation { get; set; }
        [Required] public string LocationPoint { get; set; }
        public int? LocationId { get; set; }

    }
}
