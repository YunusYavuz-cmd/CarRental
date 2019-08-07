using CarRental.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Data.Interfaces
{
    public interface IRepository<T> where T : DomainBase
    {


        int AddAndSave(T entity);
        int UpdateAndSave(T entity);
        int Save();
        int DeleteAndSave(T entity);
        T GetById(long id);
        //T Add(T entity);
        //T Delete(T entity);

    }
}
