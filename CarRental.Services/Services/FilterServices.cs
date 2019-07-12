using CarRental.Data.Interfaces;
using CarRental.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using CarRental.Services.Converters;
using System.Linq;

namespace CarRental.Services.Services
{
    public class FilterServices
    {
      private readonly ICarRepository _carRepository;
        private readonly IBookRepository _bookRepository;
        public FilterServices(ICarRepository carRepository,IBookRepository bookRepository)
       {
            carRepository = _carRepository;
            bookRepository = _bookRepository;
       }
    }
}
