using CarRental.Domain;
using CarRental.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Services.Converters
{

    public static class MiniAdvertConverter
    {

            public static MiniAdvertDto ToDto(this Car car)
            {
                if (car == null) //Does it required ? it doesnt come here with select query since there are nothing to select
                    return null;

                return new MiniAdvertDto
                {

                    CarBrand = car.CarBrand,
                    CarId = car.Id,
                    CarLocation = car.CarLocation,
                    CarModel = car.CarModel,
                    CarYear = car.CarYear
                };
        }

    }
}
