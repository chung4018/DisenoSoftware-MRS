using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace NutriApp5.Models
{ 
    public class BUSQUEDAXPRODUCTOSRepository : IBUSQUEDAXPRODUCTOSRepository
    {
        Entities context = new Entities();

        public IQueryable<BUSQUEDAXPRODUCTOS> All
        {
            get { return context.BUSQUEDAXPRODUCTOS; }
        }

        public IQueryable<BUSQUEDAXPRODUCTOS> AllIncluding(params Expression<Func<BUSQUEDAXPRODUCTOS, object>>[] includeProperties)
        {
            IQueryable<BUSQUEDAXPRODUCTOS> query = context.BUSQUEDAXPRODUCTOS;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public BUSQUEDAXPRODUCTOS Find(int id)
        {
            return context.BUSQUEDAXPRODUCTOS.Find(id);
        }

        public void InsertOrUpdate(BUSQUEDAXPRODUCTOS busquedaxproductos)
        {
            if (busquedaxproductos.ID == default(int)) {
                // New entity
                context.BUSQUEDAXPRODUCTOS.Add(busquedaxproductos);
            } else {
                // Existing entity
                context.Entry(busquedaxproductos).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var busquedaxproductos = context.BUSQUEDAXPRODUCTOS.Find(id);
            context.BUSQUEDAXPRODUCTOS.Remove(busquedaxproductos);
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

    public interface IBUSQUEDAXPRODUCTOSRepository : IDisposable
    {
        IQueryable<BUSQUEDAXPRODUCTOS> All { get; }
        IQueryable<BUSQUEDAXPRODUCTOS> AllIncluding(params Expression<Func<BUSQUEDAXPRODUCTOS, object>>[] includeProperties);
        BUSQUEDAXPRODUCTOS Find(int id);
        void InsertOrUpdate(BUSQUEDAXPRODUCTOS busquedaxproductos);
        void Delete(int id);
        void Save();
    }
}