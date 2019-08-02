using CarRental.Domain;
using CarRental.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Services.Converters
{
    public static class BookConverter
    {
        public static BookInfoDto ToBookInfoDto(this Book book)
        {
            if (book == null)
                return null;

            return new BookInfoDto
            {

                CarBrand = book.Car.CarBrand,
                CarColor = book.Car.CarColor,
                CarLocation = book.Car.CarLocation,
                CarModel = book.Car.CarModel,
                CarYear = book.Car.CarYear,
                IsManual = book.Car.IsManual,
                CustomerName = book.Customer.CustomerName,
                RentEndDate = book.RentEndDate,
                RentStartDate = book.RentStartDate
            };
        }
     
    }
}
