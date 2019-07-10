using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Services.ViewModel
{
    public class HomePageModel
    {
        public List<string> DeliveryLocations;
        public int CarId { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public string CarLocation { get; set; }
        public int CarPrice { get; set; }

    }
}
