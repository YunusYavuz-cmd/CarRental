using CarRental.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Services.Interfaces
{
    public interface IBookServices
    {

        void AddBooking(int carId, BookCustomerDto bookCustomerDto);
        BookCustomerDto GetBookInfo(int referenceNumber);
    }
}
