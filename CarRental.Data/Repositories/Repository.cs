using CarRental.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CarRental.Data.Interfaces;

namespace CarRental.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : DomainBase
    {
        protected DbSet<T> DbSet;


        protected Repository(DbSet<T> dbSet)
        {
            DbSet = dbSet;
        }

        public int AddAndSave(T entity, RentACarContext context)
        {
            DbSet.Add(entity);
            return Save(context);
        }
        public T FindById(long id)
        {
            return DbSet.FirstOrDefault(x => x.Id == id);
        }
        public int Save(RentACarContext context)
        {
            return context.SaveChanges();
        }
        public int UpdateAndSave(T entity,RentACarContext context)
        {
            DbSet.Update(entity);
            return Save(context);
        }

        //public virtual T Add(T entity)
        //{
        //    if (entity == null)
        //        throw new ArgumentNullException(nameof(entity));
        //    return DbSet.Add(entity);
        //}

        //public virtual T Delete(T entity) 
        //{
        //    if (entity == null)
        //        throw new ArgumentNullException(nameof(entity));
        //   // AttachIfNotExist(entity);
        //    return DbSet.Remove(entity);
        //}
    }
}
