using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace nutriApp3.Models
{ 
    public class BITACORA_PRODUCTOSRepository : IBITACORA_PRODUCTOSRepository
    {
        Entities context = new Entities();

        public IQueryable<BITACORA_PRODUCTOS> All
        {
            get { return context.BITACORA_PRODUCTOS; }
        }

        public IQueryable<BITACORA_PRODUCTOS> AllIncluding(params Expression<Func<BITACORA_PRODUCTOS, object>>[] includeProperties)
        {
            IQueryable<BITACORA_PRODUCTOS> query = context.BITACORA_PRODUCTOS;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public BITACORA_PRODUCTOS Find(int id)
        {
            return context.BITACORA_PRODUCTOS.Find(id);
        }

        public void InsertOrUpdate(BITACORA_PRODUCTOS bitacora_productos)
        {
            if (bitacora_productos.ID_BITACORA == default(int)) {
                // New entity
                context.BITACORA_PRODUCTOS.Add(bitacora_productos);
            } else {
                // Existing entity
                context.Entry(bitacora_productos).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var bitacora_productos = context.BITACORA_PRODUCTOS.Find(id);
            context.BITACORA_PRODUCTOS.Remove(bitacora_productos);
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

    public interface IBITACORA_PRODUCTOSRepository : IDisposable
    {
        IQueryable<BITACORA_PRODUCTOS> All { get; }
        IQueryable<BITACORA_PRODUCTOS> AllIncluding(params Expression<Func<BITACORA_PRODUCTOS, object>>[] includeProperties);
        BITACORA_PRODUCTOS Find(int id);
        void InsertOrUpdate(BITACORA_PRODUCTOS bitacora_productos);
        void Delete(int id);
        void Save();
    }
}