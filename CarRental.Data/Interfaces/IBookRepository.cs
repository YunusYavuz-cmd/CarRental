using CarRental.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Data.Interfaces
{
    public interface IBookRepository: IRepository<Book>
    {
        Book GetBookByReference(string referenceNumber);
        List<Book> FindAllBooks();
    }
}
