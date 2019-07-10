using CarRental.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Data.Interfaces
{
    public interface ICarRepository
    {
        List<Car> FindAllCars();
        List<Car> FindCarsWithFuel(CarFuelTypes carFuelTypes);
        List<Car> FindCarsWithColor(string color);
        List<Car> FindCarsWithYear(int minYear, int maxYear);
        List<Car> FindCarsWithBrand(string brandName);
        List<Car> FindCarsBetweenKm(int minKm, int maxKm);
        List<Car> FindCarsBetweenPrice(int minPrice, int maxPrice);
        bool IsManuel(int carId);
        List<Car> FindAllByLocation(string location);
        List<Car> FindCarsWithModel(string modelName);

    }
}
