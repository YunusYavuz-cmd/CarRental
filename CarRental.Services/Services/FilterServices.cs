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

        public AdvertListDto AdvertFilterKm(int kmRangeStart, int kmRangeEnd)
        {
            var d = _carRepository.FindFilters(null,null,null,null,null,null,null,null,kmRangeStart, kmRangeEnd,null,null);
            AdvertListDto advertListDto = new AdvertListDto{

              MiniAdvertList= d.Select(x => x.ToDto()).ToList()
            };
            return advertListDto;

        }
        //public MiniAdvertDto AdvertFilterModel(string carModel)
        //{
        //    return _carRepository.FindCarsWithModel(carModel);
        //}
        //public MiniAdvertDto AdvertFilterBrand(string carBrand)
        //{
        //    return _carRepository.FindCarsWithBrand(carBrand);
        //}
        //public MiniAdvertDto AdvertFilterYear(int carYearMin, int carYearMax)
        //{
        //    return _carRepository.FindCarsBetweenYear(carYearMin, carYearMax);
        //}
        //public MiniAdvertDto AdvertFilterPrice(int minPrice, int maxPrice)
        //{
        //    return _carRepository.FindCarsBetweenPrice(minPrice, maxPrice);
        //}
        //public MiniAdvertDto AdvertFilterColor(string carColor)
        //{
        //    return _carRepository.FindCarsWithColor(Color);
        //}
    }
}
