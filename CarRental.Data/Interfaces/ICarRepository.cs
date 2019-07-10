using CarRental.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Data.Interfaces
{
    public interface ICarRepository
    {
        List<Car> FindFilters(DateTime? startDate, DateTime? endDate, string carBrand, string carModel, string carColor, string carLocation,
                                       int? maxPrice, int? minPrice, int? minKm, int? maxKm, int? carFuelTypes, bool? isManuel);
        List<Car> FindAllCars();
        List<Car> FindCarsBetweenPrice(int minPrice, int maxPrice);
        List<Car> FindRandomCars(int randNum);

    }
}
