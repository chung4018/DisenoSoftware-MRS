using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace NutriApp5.Models
{ 
    public class PRODUCTOSXCOMERCIORepository : IPRODUCTOSXCOMERCIORepository
    {
        Entities context = new Entities();

        public IQueryable<PRODUCTOSXCOMERCIO> All
        {
            get { return context.PRODUCTOSXCOMERCIO; }
        }

        public IQueryable<PRODUCTOSXCOMERCIO> AllIncluding(params Expression<Func<PRODUCTOSXCOMERCIO, object>>[] includeProperties)
        {
            IQueryable<PRODUCTOSXCOMERCIO> query = context.PRODUCTOSXCOMERCIO;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public PRODUCTOSXCOMERCIO Find(int id)
        {
            return context.PRODUCTOSXCOMERCIO.Find(id);
        }

        public void InsertOrUpdate(PRODUCTOSXCOMERCIO productosxcomercio)
        {
            if (productosxcomercio.ID == default(int)) {
                // New entity
                context.PRODUCTOSXCOMERCIO.Add(productosxcomercio);
            } else {
                // Existing entity
                context.Entry(productosxcomercio).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var productosxcomercio = context.PRODUCTOSXCOMERCIO.Find(id);
            context.PRODUCTOSXCOMERCIO.Remove(productosxcomercio);
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

    public interface IPRODUCTOSXCOMERCIORepository : IDisposable
    {
        IQueryable<PRODUCTOSXCOMERCIO> All { get; }
        IQueryable<PRODUCTOSXCOMERCIO> AllIncluding(params Expression<Func<PRODUCTOSXCOMERCIO, object>>[] includeProperties);
        PRODUCTOSXCOMERCIO Find(int id);
        void InsertOrUpdate(PRODUCTOSXCOMERCIO productosxcomercio);
        void Delete(int id);
        void Save();
    }
}