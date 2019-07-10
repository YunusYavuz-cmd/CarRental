using CarRental.Data.Interfaces;
using CarRental.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRental.Data.Repositories
{
    public class BookRepository: Repository<Book> , IBookRepository
    {
        private readonly RentACarContext _context;
        public BookRepository(RentACarContext context) : base(context)
        { 
            _context = context;
        }
       
        public List<Book> FindAllBooks()
        {
            return _context.Book.ToList();
        }
  
    }
}
