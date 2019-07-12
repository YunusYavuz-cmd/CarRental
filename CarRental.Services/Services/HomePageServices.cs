using CarRental.Data;
using CarRental.Data.Interfaces;
using CarRental.Services.Converters;
using CarRental.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRental.Services.Services
{
    public class HomePageServices : IHomePageServices
    {
        private readonly ICarRepository CarRep;
        public HomePageServices(ICarRepository carRep)
        {
            CarRep = carRep;
        }
        public List<MiniAdvertDto> Reto()
        {
            var cars = CarRep.FindRandomCars(2);
            return cars.Select(x => x.ToDto()).ToList();
        }
    }
}
