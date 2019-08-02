using CarRental.Domain;
using CarRental.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Services.Converters
{
    public static class LocationConverter
    {
        public static DeleteLocationDto toDto(this Location location)
        {
            if (location == null)
                return null;
            return new DeleteLocationDto {

                LocationName = location.CityLocation,
                LocationId = location.Id
            };
        }
    }
}
