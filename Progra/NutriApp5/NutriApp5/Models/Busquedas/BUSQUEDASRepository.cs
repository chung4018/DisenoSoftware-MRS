using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace NutriApp5.Models
{ 
    public class BUSQUEDASRepository : IBUSQUEDASRepository
    {
        Entities context = new Entities();

        public IQueryable<BUSQUEDAS> All
        {
            get { return context.BUSQUEDAS; }
        }

        public IQueryable<BUSQUEDAS> AllIncluding(params Expression<Func<BUSQUEDAS, object>>[] includeProperties)
        {
            IQueryable<BUSQUEDAS> query = context.BUSQUEDAS;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public BUSQUEDAS Find(int id)
        {
            return context.BUSQUEDAS.Find(id);
        }

        public void InsertOrUpdate(BUSQUEDAS busquedas)
        {
            if (busquedas.ID_BUSQUEDA == default(int)) {
                // New entity
                context.BUSQUEDAS.Add(busquedas);
            } else {
                // Existing entity
                context.Entry(busquedas).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var busquedas = context.BUSQUEDAS.Find(id);
            context.BUSQUEDAS.Remove(busquedas);
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

    public interface IBUSQUEDASRepository : IDisposable
    {
        IQueryable<BUSQUEDAS> All { get; }
        IQueryable<BUSQUEDAS> AllIncluding(params Expression<Func<BUSQUEDAS, object>>[] includeProperties);
        BUSQUEDAS Find(int id);
        void InsertOrUpdate(BUSQUEDAS busquedas);
        void Delete(int id);
        void Save();
    }
}