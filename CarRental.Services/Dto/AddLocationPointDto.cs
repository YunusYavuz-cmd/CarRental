using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarRental.Services.Dto
{
   public class AddLocationPointDto
    {
        [Required]public string LocationIdString { get; set; }
        [Required] public string LocationPointName { get; set; }
        public int? LocationId { get; set; }
    }
}
