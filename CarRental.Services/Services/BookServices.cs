using CarRental.Data.Interfaces;
using CarRental.Domain;
using CarRental.Services.Dto;
using CarRental.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Services.Services
{
    public class BookServices : IBookServices
    {
        private readonly ICarRepository CarRep;
        private readonly IBookRepository BookRep;
        public BookServices(ICarRepository carRep, IBookRepository bookRep)
        {
            CarRep = carRep;
            BookRep = bookRep;
        }
        public void AddBooking(int carId, BookCustomerDto bookCustomerDto)
        {
            if (CarRep.IsAvaible(carId, bookCustomerDto.RentStartDate, bookCustomerDto.RentEndDate))
            {
                Car car = CarRep.GetCarById(carId);
                List<CustomerProperties> customerProperties = new List<CustomerProperties> {
                   new CustomerProperties{TypeId=1,Value=bookCustomerDto.CustomerAge },
                   new CustomerProperties{TypeId=2,Value=bookCustomerDto.CustomerLicenseAge }
                };
                Customer customer = new Customer
                {
                    CustomerEmail = bookCustomerDto.CustomerEmail,
                    CustomerPhoneNumber = bookCustomerDto.CustomerPhoneNumber,
                    CustomerName = bookCustomerDto.CustomerName,
                    CustomerProperties = customerProperties

                };
                Book book = new Book
                {
                    RentStartDate = bookCustomerDto.RentStartDate,
                    RentEndDate = bookCustomerDto.RentEndDate,
                    ReferenceNumber = bookCustomerDto.ReferenceNumber,
                    BeforeKm = car.CarKm,
                    AfterKm = car.CarKm,

                    Customer = customer,
                    Car = car,// VİRTUAL DOĞRU MU?

                };

                BookRep.AddAndSave(book);
                CarRep.AddBookToCar(carId, book);
            }
            else
            {
                //CAR IS NOT AVAIBLE BETWEEN DATES bookCustomerDto.startend.
            }
        }
        public BookCustomerDto GetBookInfo(int referenceNumber)
        {
            var bookInfo = BookRep.GetBookByReference(referenceNumber);
            //TODO: CHANGE IT TO AN DTO OBJECT

            return null;
        }
    }
}
