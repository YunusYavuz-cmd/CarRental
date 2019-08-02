using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarRental.Services.Dto
{
    public class DeleteLocationDto
    {
        [Required] public int LocationId { get; set; }
        [Required] public string LocationName { get; set; }
    }
}
