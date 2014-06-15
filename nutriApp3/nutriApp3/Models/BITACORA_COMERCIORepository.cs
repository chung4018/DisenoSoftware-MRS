using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace nutriApp3.Models
{ 
    public class BITACORA_COMERCIORepository : IBITACORA_COMERCIORepository
    {
        Entities context = new Entities();

        public IQueryable<BITACORA_COMERCIO> All
        {
            get { return context.BITACORA_COMERCIO; }
        }

        public IQueryable<BITACORA_COMERCIO> AllIncluding(params Expression<Func<BITACORA_COMERCIO, object>>[] includeProperties)
        {
            IQueryable<BITACORA_COMERCIO> query = context.BITACORA_COMERCIO;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public BITACORA_COMERCIO Find(int id)
        {
            return context.BITACORA_COMERCIO.Find(id);
        }

        public void InsertOrUpdate(BITACORA_COMERCIO bitacora_comercio)
        {
            if (bitacora_comercio.ID_BITACORA == default(int)) {
                // New entity
                context.BITACORA_COMERCIO.Add(bitacora_comercio);
            } else {
                // Existing entity
                context.Entry(bitacora_comercio).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var bitacora_comercio = context.BITACORA_COMERCIO.Find(id);
            context.BITACORA_COMERCIO.Remove(bitacora_comercio);
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

    public interface IBITACORA_COMERCIORepository : IDisposable
    {
        IQueryable<BITACORA_COMERCIO> All { get; }
        IQueryable<BITACORA_COMERCIO> AllIncluding(params Expression<Func<BITACORA_COMERCIO, object>>[] includeProperties);
        BITACORA_COMERCIO Find(int id);
        void InsertOrUpdate(BITACORA_COMERCIO bitacora_comercio);
        void Delete(int id);
        void Save();
    }
}