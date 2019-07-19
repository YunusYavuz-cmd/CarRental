using CarRental.Data.Interfaces;
using CarRental.Domain;
using CarRental.Services.Converters;
using CarRental.Services.Dto;
using CarRental.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
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
        public IOperationResult<BookInfoDto> AddBooking(BookCustomerDto bookCustomerDto) //operation result . if data is null then not avaible. book oluşturulduğunda ekrana info sayfasını vercek
        {
            if (CarRep.IsAvaible(bookCustomerDto.carId, bookCustomerDto.RentStartDate, bookCustomerDto.RentEndDate))
            {
                Book book = CreateBooking(bookCustomerDto);
                BookRep.AddAndSave(book);
                CarRep.AddBookToCar(bookCustomerDto.carId, book);
                return new OperationResult<BookInfoDto>(true, "Successfully booked", (int)HttpStatusCode.OK, book.ToBookInfoDto());
            }
            else
            {
                return new OperationResult<BookInfoDto>(false, "These dates are not available for the selected car", (int) HttpStatusCode.NotFound, null);
            }
            
        }
        private Book CreateBooking(BookCustomerDto bookCustomerDto)
        {

            Car car = CarRep.GetCarById(bookCustomerDto.carId);
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
                Car = car

            };
            return book;
        }
        public BookInfoDto GetBookInfo(int referenceNumber)
        {
            var bookInfo = BookRep.GetBookByReference(referenceNumber);
            return bookInfo.ToBookInfoDto();
        }
    }
}
