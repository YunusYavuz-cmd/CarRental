using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CarRental.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Data
{
    public class RentACarContext : DbContext
    {
        public RentACarContext(DbContextOptions<RentACarContext> options) : base(options)
        {


        }
        public DbSet<Car> Car { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<CustomerProperties> CustomerProperties { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<LocationPoint> LocationPoint { get; set; }
        public DbSet<PriceTable> PriceTable { get; set; }


    }
}
