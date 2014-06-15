using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace nutriApp3.Models
{ 
    public class BITACORA_NOTICIASRepository : IBITACORA_NOTICIASRepository
    {
        Entities context = new Entities();

        public IQueryable<BITACORA_NOTICIAS> All
        {
            get { return context.BITACORA_NOTICIAS; }
        }

        public IQueryable<BITACORA_NOTICIAS> AllIncluding(params Expression<Func<BITACORA_NOTICIAS, object>>[] includeProperties)
        {
            IQueryable<BITACORA_NOTICIAS> query = context.BITACORA_NOTICIAS;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public BITACORA_NOTICIAS Find(int id)
        {
            return context.BITACORA_NOTICIAS.Find(id);
        }

        public void InsertOrUpdate(BITACORA_NOTICIAS bitacora_noticias)
        {
            if (bitacora_noticias.ID_BITACORA == default(int)) {
                // New entity
                context.BITACORA_NOTICIAS.Add(bitacora_noticias);
            } else {
                // Existing entity
                context.Entry(bitacora_noticias).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var bitacora_noticias = context.BITACORA_NOTICIAS.Find(id);
            context.BITACORA_NOTICIAS.Remove(bitacora_noticias);
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

    public interface IBITACORA_NOTICIASRepository : IDisposable
    {
        IQueryable<BITACORA_NOTICIAS> All { get; }
        IQueryable<BITACORA_NOTICIAS> AllIncluding(params Expression<Func<BITACORA_NOTICIAS, object>>[] includeProperties);
        BITACORA_NOTICIAS Find(int id);
        void InsertOrUpdate(BITACORA_NOTICIAS bitacora_noticias);
        void Delete(int id);
        void Save();
    }
}