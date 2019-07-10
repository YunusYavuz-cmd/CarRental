using CarRental.Domain;
using CarRental.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Services.Converters
{

    public static class MiniAdvertConverter
    {
        //public static List<MiniAdvertDto> toAdvertListDto(this List<Car> carList)
        //{
        //    List<MiniAdvertDto> miniAdvertDtos=new List<MiniAdvertDto>();
        //      foreach(var car in carList)
        //       {
        //        MiniAdvertDto miniAdvert = new MiniAdvertDto {

        //            CarBrand = car.CarBrand,
        //            CarId = car.CarId,
        //            CarLocation = car.CarLocation,
        //            CarModel = car.CarModel,
        //            CarYear = car.CarYear
        //        };
        //        miniAdvertDtos.Add(miniAdvert);
        //    }
        //    return miniAdvertDtos;
        //}

        public static MiniAdvertDto ToDto(this Car car)
        {
            if (car == null)
                return null;

            return new MiniAdvertDto
            {

                CarBrand = car.CarBrand,
                CarId = car.CarId,
                CarLocation = car.CarLocation,
                CarModel = car.CarModel,
                CarYear = car.CarYear
            };
        }

    }
}
