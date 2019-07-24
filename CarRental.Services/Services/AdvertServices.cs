using CarRental.Data.Interfaces;
using CarRental.Services.Converters;
using CarRental.Services.Dto;
using CarRental.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRental.Services.Services
{
    public class AdvertServices: IAdvertServices
    {
        private readonly ICarRepository _carRepository;

        public AdvertServices(ICarRepository carRepository)
        {

            _carRepository = carRepository;

        }
    
        public AdvertDetailedDto GetAdvertById(int advertId)
        {
            return _carRepository.GetCarById(advertId).ToDetailedDto();
        }
        
    }
}
