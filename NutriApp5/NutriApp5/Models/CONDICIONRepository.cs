using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace NutriApp5.Models
{ 
    public class CONDICIONRepository : ICONDICIONRepository
    {
        Entities context = new Entities();

        public IQueryable<CONDICION> All
        {
            get { return context.CONDICION; }
        }

        public IQueryable<CONDICION> AllIncluding(params Expression<Func<CONDICION, object>>[] includeProperties)
        {
            IQueryable<CONDICION> query = context.CONDICION;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public CONDICION Find(decimal id)
        {
            return context.CONDICION.Find(id);
        }

        public void InsertOrUpdate(CONDICION condicion)
        {
            if (condicion.ID_CONDICION == default(decimal)) {
                // New entity
                context.CONDICION.Add(condicion);
            } else {
                // Existing entity
                context.Entry(condicion).State = EntityState.Modified;
            }
        }

        public void Delete(decimal id)
        {
            var condicion = context.CONDICION.Find(id);
            context.CONDICION.Remove(condicion);
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

    public interface ICONDICIONRepository : IDisposable
    {
        IQueryable<CONDICION> All { get; }
        IQueryable<CONDICION> AllIncluding(params Expression<Func<CONDICION, object>>[] includeProperties);
        CONDICION Find(decimal id);
        void InsertOrUpdate(CONDICION condicion);
        void Delete(decimal id);
        void Save();
    }
}