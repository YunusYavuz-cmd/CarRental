using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Services.Dto
{
    public class MiniAdvertDto
    {
        public int CarId { get; set; }
        public string CarBrand { get; set; }
        public int CarYear { get; set; }
        
        public string CarModel { get; set; }
        public string CarLocation { get; set; }
    }
}
