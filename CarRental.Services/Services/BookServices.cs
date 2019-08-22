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
        private readonly ICarRepository CarRepository;
        private readonly IBookRepository BookRepository;
        private readonly ICustomerRepository CustomerRepository;

        public BookServices(ICarRepository carRepository, IBookRepository bookRepository,ICustomerRepository customerRepository)
        {
            CarRepository = carRepository;
            BookRepository = bookRepository;
            CustomerRepository = customerRepository;
        }
        public OperationResult<BookInfoDto> AddBooking(BookRequestDto bookRequestDto) //operation result . if data is null then not avaible. book oluşturulduğunda ekrana info sayfasını vercek
        {
            if (CarRepository.IsAvaible(bookRequestDto.carId, bookRequestDto.RentStartDate, bookRequestDto.RentEndDate))
            {
                var book = CreateBooking(bookRequestDto);
                BookRepository.AddAndSave(book);
                return new OperationResult<BookInfoDto>(true, "Successfully booked", (int)HttpStatusCode.OK, book.ToBookInfoDto());
            }
            else
            {
                return new OperationResult<BookInfoDto>(false, "These dates are not available for the selected car", (int) HttpStatusCode.NotFound, null);
            } 
        }
        public BookInfoDto GetBookInfo(string referenceNumber)
        {
            var bookInfo = BookRepository.GetBookByReference(referenceNumber);
            return bookInfo.ToBookInfoDto();
        }
        private Book CreateBooking(BookRequestDto bookRequestDto)
        {

            var car = CarRepository.GetById(bookRequestDto.carId);
            int? customerId;
            List<CustomerProperties> customerProperties = new List<CustomerProperties> {
                   new CustomerProperties{TypeId=1,Value=bookRequestDto.CustomerAge },
                   new CustomerProperties{TypeId=2,Value=bookRequestDto.CustomerLicenseAge }
                };
            if(!CustomerRepository.IsCustomerExist(bookRequestDto.CustomerEmail))
            {
                customerId=CustomerRepository.GetCustomerId(bookRequestDto.CustomerEmail);
            
            }
            else
            {

                var customer = new Customer //TODO: check customer exist
                {
                    CustomerEmail = bookRequestDto.CustomerEmail,
                    CustomerPhoneNumber = bookRequestDto.CustomerPhoneNumber,
                    CustomerName = bookRequestDto.CustomerName,
                    CustomerProperties = customerProperties

                };
                CustomerRepository.AddAndSave(customer);
                customerId = customer.Id;
            }

            var book = new Book
            {
                RentStartDate = bookRequestDto.RentStartDate,
                RentEndDate = bookRequestDto.RentEndDate,
                ReferenceNumber = CreateReferenceNumber(),
                BeforeKm = car.CarKm,
                AfterKm = car.CarKm,
                CustomerId = (int) customerId,
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
