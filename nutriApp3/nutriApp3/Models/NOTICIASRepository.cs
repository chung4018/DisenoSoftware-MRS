using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace nutriApp3.Models
{ 
    public class NOTICIASRepository : INOTICIASRepository
    {
        Entities context = new Entities();

        public IQueryable<NOTICIAS> All
        {
            get { return context.NOTICIAS; }
        }

        public IQueryable<NOTICIAS> AllIncluding(params Expression<Func<NOTICIAS, object>>[] includeProperties)
        {
            IQueryable<NOTICIAS> query = context.NOTICIAS;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public NOTICIAS Find(int id)
        {
            return context.NOTICIAS.Find(id);
        }

        public void InsertOrUpdate(NOTICIAS noticias)
        {
            if (noticias.ID_NOTICIA == default(int)) {
                // New entity
                context.NOTICIAS.Add(noticias);
            } else {
                // Existing entity
                context.Entry(noticias).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var noticias = context.NOTICIAS.Find(id);
            context.NOTICIAS.Remove(noticias);
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

    public interface INOTICIASRepository : IDisposable
    {
        IQueryable<NOTICIAS> All { get; }
        IQueryable<NOTICIAS> AllIncluding(params Expression<Func<NOTICIAS, object>>[] includeProperties);
        NOTICIAS Find(int id);
        void InsertOrUpdate(NOTICIAS noticias);
        void Delete(int id);
        void Save();
    }
}