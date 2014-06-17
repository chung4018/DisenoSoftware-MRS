using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace NutriApp5.Models
{ 
    public class COMERCIOSRepository : ICOMERCIOSRepository
    {
        Entities context = new Entities();

        public IQueryable<COMERCIOS> All
        {
            get { return context.COMERCIOS; }
        }

        public IQueryable<COMERCIOS> AllIncluding(params Expression<Func<COMERCIOS, object>>[] includeProperties)
        {
            IQueryable<COMERCIOS> query = context.COMERCIOS;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public COMERCIOS Find(int id)
        {
            return context.COMERCIOS.Find(id);
        }

        public void InsertOrUpdate(COMERCIOS comercios)
        {
            if (comercios.ID_COMERCIO == default(int)) {
                // New entity
                context.COMERCIOS.Add(comercios);
            } else {
                // Existing entity
                context.Entry(comercios).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var comercios = context.COMERCIOS.Find(id);
            context.COMERCIOS.Remove(comercios);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose() 
        {
            context.Dispose();
        }
    }

    public interface ICOMERCIOSRepository : IDisposable
    {
        IQueryable<COMERCIOS> All { get; }
        IQueryable<COMERCIOS> AllIncluding(params Expression<Func<COMERCIOS, object>>[] includeProperties);
        COMERCIOS Find(int id);
        void InsertOrUpdate(COMERCIOS comercios);
        void Delete(int id);
        void Save();
    }
}