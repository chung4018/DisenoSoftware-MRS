using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace nutriApp3.Models
{ 
    public class TIPO_PRODUCTORepository : ITIPO_PRODUCTORepository
    {
        Entities context = new Entities();

        public IQueryable<TIPO_PRODUCTO> All
        {
            get { return context.TIPO_PRODUCTO; }
        }

        public IQueryable<TIPO_PRODUCTO> AllIncluding(params Expression<Func<TIPO_PRODUCTO, object>>[] includeProperties)
        {
            IQueryable<TIPO_PRODUCTO> query = context.TIPO_PRODUCTO;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public TIPO_PRODUCTO Find(decimal id)
        {
            return context.TIPO_PRODUCTO.Find(id);
        }

        public void InsertOrUpdate(TIPO_PRODUCTO tipo_producto)
        {
            if (tipo_producto.ID_TIPO == default(decimal)) {
                // New entity
                context.TIPO_PRODUCTO.Add(tipo_producto);
            } else {
                // Existing entity
                context.Entry(tipo_producto).State = EntityState.Modified;
            }
        }

        public void Delete(decimal id)
        {
            var tipo_producto = context.TIPO_PRODUCTO.Find(id);
            context.TIPO_PRODUCTO.Remove(tipo_producto);
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

    public interface ITIPO_PRODUCTORepository : IDisposable
    {
        IQueryable<TIPO_PRODUCTO> All { get; }
        IQueryable<TIPO_PRODUCTO> AllIncluding(params Expression<Func<TIPO_PRODUCTO, object>>[] includeProperties);
        TIPO_PRODUCTO Find(decimal id);
        void InsertOrUpdate(TIPO_PRODUCTO tipo_producto);
        void Delete(decimal id);
        void Save();
    }
}