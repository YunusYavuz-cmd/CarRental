using Microsoft.EntityFrameworkCore;
using CarRental.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using CarRental.Data.Interfaces;
using System.Linq;

namespace CarRental.Data.Repositories
{

    public class CarRepository :Repository<Car> , ICarRepository 
    {
        private readonly RentACarContext _context;

        public CarRepository(RentACarContext context): base(context.Car)
        {
            _context = context;
        }
       
 
        public List<Car> FindAllByLocation(string carBrand,string carModel,string carColor, string carLocation,int? minKm,int? maxKm)
        {
            var query = DbSet.AsQueryable();
       
            if (!string.IsNullOrEmpty(carLocation))
                query = query.Where(x => x.CarLocation == carLocation);
            if (!string.IsNullOrEmpty(carBrand))
                query = query.Where(x => x.CarBrand == carBrand);
            if (!string.IsNullOrEmpty(carModel))
                query = query.Where(x => x.CarModel == carModel);
            if (!string.IsNullOrEmpty(carColor))
                query = query.Where(x => x.CarColor == carColor);
            if (minKm.HasValue)
                query = query.Where(x => x.CarKm >= minKm.Value);
            if(maxKm.HasValue)
                query = query.Where(x => x.CarKm <= maxKm.Value);

            return query.ToList();
        }
        public List<Car> FindAllCars()
        {
            return _context.Car.ToList();               
        }
        public bool IsManuel(int carId)
        {
            return _context.Car.Where(x => x.CarId == carId).Select(s => s.IsManual).FirstOrDefault();
        }
        public List<Car> FindCarsBetweenPrice(int minPrice,int maxPrice)
        {
            return null;        //price table olcaksa ordan?
        }
        public List<Car> FindCarsBetweenKm(int minKm,int maxKm)
        {
            return _context.Car.Where(x => x.CarKm >= minKm && x.CarKm <= maxKm).ToList();
        }
        public List<Car> FindCarsWithBrand(string brandName)
        {
            return _context.Car.Where(x => x.CarBrand == brandName).ToList();
        }
        public List<Car> FindCarsWithModel(string modelName)
        {
            return _context.Car.Where(x => x.CarModel == modelName).ToList();
        }
        public List<Car> FindCarsWithYear(int minYear, int maxYear)
        {
            return _context.Car.Where(x => x.CarYear >= minYear && x.CarYear <= maxYear).ToList();
        }
        public List<Car> FindCarsWithColor(string color)
        {
            return _context.Car.Where(x => x.CarColor == color).ToList();
        }
        public List<Car> FindCarsWithFuel(CarFuelTypes carFuelTypes)
        {
            return _context.Car.Where(x => x.CarFuelTypes == carFuelTypes).ToList();
        }
        public List<Car> GetCarsWithIdList(List<int> list)
        {

            return _context.Car.Where(x => !list.Contains(x.CarId)).ToList();  
          //  _context.Book.Where(y => y.RentEndDate > dateStart && y.RentStartDate < dateEnd).Select(t => t.CarId).ToList();

        }
    }
}
