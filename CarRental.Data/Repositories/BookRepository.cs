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
        public BookRepository(RentACarContext context) : base(context.Book)
        { 
            _context = context;
        }
        public void InsertBook(int bookId, int carId, int rentedCarNum, DateTime rentStartDate, DateTime rentEndDate, int beforeKm, int afterKm)
        {
            _context.Set<Book>().Add(new Book
            {
                BookId = bookId,
                CarId = carId,
                RentedCarNum = rentedCarNum,
                RentStartDate = rentStartDate,
                RentEndDate = rentEndDate,
                BeforeKm = beforeKm,
                AfterKm = afterKm,

            });
        }
        public List<Book> FindAllBooks()
        {
            return _context.Book.ToList();
        }
        public List<int> FindCarIdBetweenDates(DateTime startDate,DateTime endDate)
        {
            return _context.Book.Where(y => y.RentEndDate > startDate && y.RentStartDate < endDate).Select(t => t.CarId).ToList();
        }
    }
}
