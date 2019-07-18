using CarRental.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Services.Interfaces
{
    public interface IAdvertServices
    {
       List<AdvertDetailedDto> AdvertFilters(DateTime? startDate, DateTime? endDate, string carBrand, string carModel, string carColor,
                                                       string carLocation, int? maxPrice, int? minPrice, int? minKm, int? maxKm, int? carFuelTypes, bool? isManuel);
       AdvertDetailedDto GetAdvertById(int advertId);
    }
}
