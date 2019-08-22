using CarRental.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Data.Interfaces
{
    public interface ICustomerRepository: IRepository<Customer>
    {
        bool IsCustomerExist(string customerEmail);
        int? GetCustomerId(string customerEmail); 
    }
}
