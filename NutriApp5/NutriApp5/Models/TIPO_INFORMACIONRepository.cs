using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace NutriApp5.Models
{ 
    public class TIPO_INFORMACIONRepository : ITIPO_INFORMACIONRepository
    {
        Entities context = new Entities();

        public IQueryable<TIPO_INFORMACION> All
        {
            get { return context.TIPO_INFORMACION; }
        }

        public IQueryable<TIPO_INFORMACION> AllIncluding(params Expression<Func<TIPO_INFORMACION, object>>[] includeProperties)
        {
            IQueryable<TIPO_INFORMACION> query = context.TIPO_INFORMACION;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public TIPO_INFORMACION Find(decimal id)
        {
            return context.TIPO_INFORMACION.Find(id);
        }

        public void InsertOrUpdate(TIPO_INFORMACION tipo_informacion)
        {
            if (tipo_informacion.ID_TIPO == default(decimal)) {
                // New entity
                context.TIPO_INFORMACION.Add(tipo_informacion);
            } else {
                // Existing entity
                context.Entry(tipo_informacion).State = EntityState.Modified;
            }
        }

        public void Delete(decimal id)
        {
            var tipo_informacion = context.TIPO_INFORMACION.Find(id);
            context.TIPO_INFORMACION.Remove(tipo_informacion);
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

    public interface ITIPO_INFORMACIONRepository : IDisposable
    {
        IQueryable<TIPO_INFORMACION> All { get; }
        IQueryable<TIPO_INFORMACION> AllIncluding(params Expression<Func<TIPO_INFORMACION, object>>[] includeProperties);
        TIPO_INFORMACION Find(decimal id);
        void InsertOrUpdate(TIPO_INFORMACION tipo_informacion);
        void Delete(decimal id);
        void Save();
    }
}