using CarRental.Data;
using CarRental.Data.Interfaces;
using CarRental.Domain;
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
        private readonly ILocationRepository LocationRepository;
        private readonly ILocationPointRepository LocationPointRepository;
        public HomePageServices(ICarRepository carRep,ILocationRepository locationRepository,ILocationPointRepository locationPointRepository)
        {
            CarRep = carRep;
            LocationPointRepository = locationPointRepository;
            LocationRepository = locationRepository;
        }

        public List<string> GetLocationNamesList()
        {
            return LocationRepository.GetAllLocationNames();
        }
        public List<MiniAdvertDto> RandomCars()
        {
            var cars = CarRep.FindRandomCars(2);
            return cars.Select(x => x.ToDto()).ToList();
        }
        public List<string> GetLocationPointsList()
        {
            return LocationPointRepository.GetAllLocationPointNames();
        }
        //public void AddCarTest(Car car)
        //{
        //    CarRep.AddAndSave(car);
        //}
    }
}   