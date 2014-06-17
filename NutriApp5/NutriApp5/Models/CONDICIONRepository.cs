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
                condicion.ID_CONDICION = getLastNumber() + 1;
                context.CONDICION.Add(condicion);
                context.SaveChanges();
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
        //recupera el ultimo registro de la base de datos  para los usuarios
        private decimal getLastNumber()
        {
            decimal resp = 0;
            IQueryable<CONDICION> condiciones = (from CONDICION p in context.CONDICION
                                          select p);
            foreach (var condicion in condiciones)
            {
                resp = condicion.ID_CONDICION;
            }

            return resp;
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