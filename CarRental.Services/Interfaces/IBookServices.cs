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

        OperationResult<BookInfoDto> AddBooking(BookRequestDto bookCustomerDto);
        BookInfoDto GetBookInfo(string referenceNumber);
       //private create booking
    }
}
