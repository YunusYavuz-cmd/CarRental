using CarRental.Data.Interfaces;
using CarRental.Services.Converters;
using CarRental.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRental.Services.Services
{
    public class AdvertServices
    {
        private readonly ICarRepository _carRepository;

        public AdvertServices(ICarRepository carRepository)
        {

            _carRepository = carRepository;

        }
        public List<AdvertDetailedDto> AdvertFilters(DateTime? startDate, DateTime? endDate, string carBrand, string carModel, string carColor, string carLocation,
                                      int? maxPrice, int? minPrice, int? minKm, int? maxKm, int? carFuelTypes, bool? isManuel)
        {
            var carListWithFilters = _carRepository.FindFilters(startDate, endDate, carBrand, carModel, carColor, carLocation, maxPrice,
                minPrice, minKm, maxKm, carFuelTypes, isManuel);

            return carListWithFilters.Select(x => x.ToDetailedDto()).ToList();

            
        }
    }
}
