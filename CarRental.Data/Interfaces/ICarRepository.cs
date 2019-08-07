using CarRental.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Data.Interfaces
{
    public interface ICarRepository : IRepository<Car>
    {
        List<Car> FindFilters(DateTime? startDate, DateTime? endDate, string carBrand, string carModel, string carColor, string carLocation,
                                       int? maxPrice, int? minPrice, int? minKm, int? maxKm, int? carFuelTypes, bool? isManuel,int? carStyle);
        List<Car> FindAllCars();
        int? FindCarPriceBetweenDates(int carId, DateTime startDate, DateTime endDate);    
        List<Car> FindRandomCars(int randNum);
        bool IsAvaible(int carId, DateTime startDate, DateTime endDate);
        void AddBookToCar(int carId, Book book);
            
    }
}
