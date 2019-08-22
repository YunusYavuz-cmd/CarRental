using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarRental.Data;
using CarRental.Data.Interfaces;
using CarRental.Domain;
namespace CarRental.Data.Repositories
{
    public class CustomerRepository :Repository<Customer> ,  ICustomerRepository
    {
        private readonly RentACarContext _context;

        public CustomerRepository(RentACarContext context)
            : base(context)
        {
            _context = context;
        }
        
        public List<Customer> FindAllCustomers()
        {
            return _context.Customer.ToList();
        }
        public bool IsCustomerExist(string customerEmail)
        {
            return DbSet.Any(x => x.CustomerEmail == customerEmail);
        }
        public int? GetCustomerId(string customerEmail)
        {
            return DbSet.Where(x => x.CustomerEmail == customerEmail).Select(x => x.Id).FirstOrDefault();
        }

    }
}
