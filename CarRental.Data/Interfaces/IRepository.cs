using CarRental.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Data.Interfaces
{
    public interface IRepository<T> where T : DomainBase
    {


        int AddAndSave(T entity,RentACarContext context);
        int UpdateAndSave(T entity,RentACarContext context);
        int Save(RentACarContext context);
        //T FindById(long id);
        //T Add(T entity);
        //T Delete(T entity);

    }
}
