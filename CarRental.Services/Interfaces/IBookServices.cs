using CarRental.Domain;
using CarRental.Services.Dto;
using CarRental.Services.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Services.Interfaces
{
    public interface IBookServices
    {

        IOperationResult<BookInfoDto> AddBooking(BookCustomerDto bookCustomerDto);
        BookInfoDto GetBookInfo(int referenceNumber);
       //private create booking
    }
}
