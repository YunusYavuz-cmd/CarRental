using CarRental.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Data.Interfaces
{
    public interface IBookRepository: IRepository<Book>
    {
        Book GetBookByReference(int referenceNumber);
        List<Book> FindAllBooks();
    }
}
