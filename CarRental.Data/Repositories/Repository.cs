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
        protected RentACarContext Context;
        protected virtual DbSet<T> DbSet => Context.Set<T>() ;
        protected Repository(RentACarContext dbContext)
        {
            Context = dbContext;
        }

        public int AddAndSave(T entity)
        {
            DbSet.Add(entity);
            return Save();
        }
        public T FindById(long id)
        {
            return DbSet.FirstOrDefault(x => x.Id == id);
        }

        public virtual T Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            AttachIfNotExist(entity);
            return DbSet.Remove(entity).Entity;
        }

        public virtual bool AttachIfNotExist(T entity)
        {
            if (Context.Entry(entity) != null && Context.Entry(entity).State != EntityState.Detached)
                return false;
            Attach(entity);
            return true;
        }
        public virtual int DeleteAndSave(T entity)
        {
            Delete(entity);
            return Save();
        }

        public int Save()
        {
            return Context.SaveChanges();
        }
        public int UpdateAndSave(T entity)
        {
            DbSet.Update(entity);
            return Save();
        }
        public virtual void Attach(T entitiy)
        {
            DbSet.Attach(entitiy);
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
