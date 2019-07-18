using System.Collections.Generic;
using CarRental.Domain;
using CarRental.Services.Dto;

namespace CarRental.Services.Services
{
    public interface IHomePageServices
    {
        List<MiniAdvertDto> Reto();
        void AddCarTest(Car car);
    }
}