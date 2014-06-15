using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace nutriApp3.Models
{ 
    public class PRODUCTOSRepository : IPRODUCTOSRepository
    {
        Entities context = new Entities();

        public IQueryable<PRODUCTOS> All
        {
            get { return context.PRODUCTOS; }
        }

        public IQueryable<PRODUCTOS> AllIncluding(params Expression<Func<PRODUCTOS, object>>[] includeProperties)
        {
            IQueryable<PRODUCTOS> query = context.PRODUCTOS;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public PRODUCTOS Find(int id)
        {
            return context.PRODUCTOS.Find(id);
        }

        public void InsertOrUpdate(PRODUCTOS productos)
        {
            if (productos.ID_PRODUCTO == default(int)) {
                // New entity
                context.PRODUCTOS.Add(productos);
            } else {
                // Existing entity
                context.Entry(productos).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var productos = context.PRODUCTOS.Find(id);
            context.PRODUCTOS.Remove(productos);
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

    public interface IPRODUCTOSRepository : IDisposable
    {
        IQueryable<PRODUCTOS> All { get; }
        IQueryable<PRODUCTOS> AllIncluding(params Expression<Func<PRODUCTOS, object>>[] includeProperties);
        PRODUCTOS Find(int id);
        void InsertOrUpdate(PRODUCTOS productos);
        void Delete(int id);
        void Save();
    }
}