using CarRental.Domain;
using CarRental.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Services.Converters
{ }
    public static class AdvertDetailedConverter
    {
        public static AdvertDetailedDto ToDetailedDto(this Car car)
        {
            if (car == null)
                return null;

            return new AdvertDetailedDto
            {

                CarBrand = car.CarBrand,
                CarColor=car.CarColor,
                CarFuelTypes=(int ) car.CarFuelTypes,
                CarKm=car.CarKm,
                //CarPrice=car.PriceTables TODO: ADD PRICE  
                CarId = car.Id,
                CarLocation = car.CarLocation,
                CarModel = car.CarModel,
                CarYear = car.CarYear
            };
        }
}
