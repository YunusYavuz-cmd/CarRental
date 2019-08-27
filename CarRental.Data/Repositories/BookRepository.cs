using CarRental.Data.Interfaces;
using CarRental.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRental.Data.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {

        public BookRepository(RentACarContext context) : base(context)
        {
        }

        public List<Book> FindAllBooks()
        {
            return DbSet.ToList();
        }
        public int GetBookIdByReference(int referenceNumber)
        {
            return DbSet.Where(t => t.Id == referenceNumber).Select(x => x.Id).FirstOrDefault(); // == id).Select(t => (int?)t.MemberId).FirstOrDefault();
        }
        public Book GetBookByReference(string referenceNumber)
        {
            return DbSet.Where(x => x.ReferenceNumber == referenceNumber).FirstOrDefault();
        }
  
    }
}
