﻿using Microsoft.EntityFrameworkCore;
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

        public CarRepository(RentACarContext context): base(context)
        {
        }
        public List<Car> FindFilters(DateTime? startDate,DateTime? endDate,string carBrand, string carModel, string carColor, string carLocation,
                                     int? maxPrice,int? minPrice,int? minKm, int? maxKm, int? carFuelTypes, bool? isManuel,int? carStyle)
        {
            var query = DbSet.AsQueryable();
            if (maxPrice.HasValue)
                query = query.Where(x => x.PriceTables.Any(y => y.CarPrice <= maxPrice && y.CarPrice >= minPrice)); //TODO:  WILL ADD PRICETABLE DATES TO QUERY !!!
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
            if (carStyle.HasValue)
                query = query.Where(x => x.CarStyle == (Car.CarStyles)carStyle.Value);
            if (maxKm.HasValue)
                query = query.Where(x => x.CarKm <= maxKm.Value);
            if (carFuelTypes.HasValue)
            {
                if (carFuelTypes == 1)
                    query = query.Where(x =>(int) x.CarFuelType == carFuelTypes);
                else if (carFuelTypes == 2)
                    query = query.Where(x => (int)x.CarFuelType == carFuelTypes);
                else if (carFuelTypes == 3)
                    query = query.Where(x => (int)x.CarFuelType == carFuelTypes);
            }
            if (startDate.HasValue && endDate.HasValue)
            {
                query = query.Where(x => x.Books.Any(y => (y.RentEndDate < startDate ) || (y.RentStartDate > endDate)));
            }
            if (isManuel.HasValue)
                query = query.Where(x => x.IsManual == isManuel);
            return query.ToList();
        }
        public List<Car> FindAllCars()
        {
            return DbSet.ToList();               
        }
        public int? FindCarPriceBetweenDates(int carId, DateTime startDate,DateTime endDate)
        {
         
        //DbSet.Where(x => x.Id == carId && x.PriceTables.Select(y => (y.EndDate < startDate) || (y.StartDate > endDate)).FirstOrDefault());     
            return null;
        }
        public List<Car> FindByStyle(int carStyle)
        {
            return DbSet.Where(x => x.CarStyle == (Car.CarStyles)carStyle).ToList();
        }
        public List<Car> FindRandomCars(int randNum)
        {
               return DbSet.OrderBy(r => Guid.NewGuid()).Take(randNum).ToList();
        }
        public Car GetCarById(int carId)
        {
            return DbSet.Where(x => x.Id == carId).FirstOrDefault();
        }
        public bool IsAvaible(int carId,DateTime startDate,DateTime endDate)
        {
            Car car= DbSet.Where(x =>x.Id==carId && x.Books.All(y => (y.RentEndDate < startDate) || (y.RentStartDate>endDate) )).FirstOrDefault();  
            if (car == null)
                return false;
            return true;
        }
        public void AddBookToCar(int carId,Book book)
        {
            Car car = DbSet.Where(x => x.Id == carId).FirstOrDefault();
            if (car == null)
                throw new Exception("Car does not exist in Database");
            else {

                if (car.Books == null)
                    car.Books = new List<Book>();

                car.Books.Add(book);

            }
        }
    }
}
