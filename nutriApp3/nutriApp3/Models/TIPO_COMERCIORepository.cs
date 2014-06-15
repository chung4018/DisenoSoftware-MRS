using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace nutriApp3.Models
{ 
    public class TIPO_COMERCIORepository : ITIPO_COMERCIORepository
    {
        Entities context = new Entities();

        public IQueryable<TIPO_COMERCIO> All
        {
            get { return context.TIPO_COMERCIO; }
        }

        public IQueryable<TIPO_COMERCIO> AllIncluding(params Expression<Func<TIPO_COMERCIO, object>>[] includeProperties)
        {
            IQueryable<TIPO_COMERCIO> query = context.TIPO_COMERCIO;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public TIPO_COMERCIO Find(decimal id)
        {
            return context.TIPO_COMERCIO.Find(id);
        }

        public void InsertOrUpdate(TIPO_COMERCIO tipo_comercio)
        {
            if (tipo_comercio.ID_TIPO == default(decimal)) {
                // New entity
                context.TIPO_COMERCIO.Add(tipo_comercio);
            } else {
                // Existing entity
                context.Entry(tipo_comercio).State = EntityState.Modified;
            }
        }

        public void Delete(decimal id)
        {
            var tipo_comercio = context.TIPO_COMERCIO.Find(id);
            context.TIPO_COMERCIO.Remove(tipo_comercio);
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

    public interface ITIPO_COMERCIORepository : IDisposable
    {
        IQueryable<TIPO_COMERCIO> All { get; }
        IQueryable<TIPO_COMERCIO> AllIncluding(params Expression<Func<TIPO_COMERCIO, object>>[] includeProperties);
        TIPO_COMERCIO Find(decimal id);
        void InsertOrUpdate(TIPO_COMERCIO tipo_comercio);
        void Delete(decimal id);
        void Save();
    }
}