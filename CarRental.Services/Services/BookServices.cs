using CarRental.Data.Interfaces;
using CarRental.Domain;
using CarRental.Services.Converters;
using CarRental.Services.Dto;
using CarRental.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;

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
        public OperationResult<BookInfoDto> AddBooking(BookRequestDto bookRequestDto) //operation result . if data is null then not avaible. book oluşturulduğunda ekrana info sayfasını vercek
        {
            if (CarRep.IsAvaible(bookRequestDto.carId, bookRequestDto.RentStartDate, bookRequestDto.RentEndDate))
            {
                var book = CreateBooking(bookRequestDto);
                BookRep.AddAndSave(book);
                return new OperationResult<BookInfoDto>(true, "Successfully booked", (int)HttpStatusCode.OK, book.ToBookInfoDto());
            }
            else
            {
                return new OperationResult<BookInfoDto>(false, "These dates are not available for the selected car", (int) HttpStatusCode.NotFound, null);
            }
            
        }
        public BookInfoDto GetBookInfo(string referenceNumber)
        {
            var bookInfo = BookRep.GetBookByReference(referenceNumber);
            return bookInfo.ToBookInfoDto();
        }
        private Book CreateBooking(BookRequestDto bookRequestDto)
        {

            var car = CarRep.GetById(bookRequestDto.carId);
          
            List<CustomerProperties> customerProperties = new List<CustomerProperties> {
                   new CustomerProperties{TypeId=1,Value=bookRequestDto.CustomerAge },
                   new CustomerProperties{TypeId=2,Value=bookRequestDto.CustomerLicenseAge }
                };
            var customer = new Customer //TODO: check customer exist
            {
                CustomerEmail = bookRequestDto.CustomerEmail,
                CustomerPhoneNumber = bookRequestDto.CustomerPhoneNumber,
                CustomerName = bookRequestDto.CustomerName,
                CustomerProperties = customerProperties

            };
            var book = new Book
            {
                RentStartDate = bookRequestDto.RentStartDate,
                RentEndDate = bookRequestDto.RentEndDate,
                ReferenceNumber = CreateReferenceNumber(),
                BeforeKm = car.CarKm,
                AfterKm = car.CarKm,
                CustomerId = customer.Id,
                CarId = car.Id  
            };
            return book;
        }
        private string CreateReferenceNumber()
        {
            return Guid.NewGuid().ToString();

        }
       

    }
}
