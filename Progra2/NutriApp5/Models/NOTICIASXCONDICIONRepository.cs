using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace NutriApp5.Models
{ 
    public class NOTICIASXCONDICIONRepository : INOTICIASXCONDICIONRepository
    {
        Entities context = new Entities();

        public IQueryable<NOTICIASXCONDICION> All
        {
            get { return context.NOTICIASXCONDICION; }
        }

        public IQueryable<NOTICIASXCONDICION> AllIncluding(params Expression<Func<NOTICIASXCONDICION, object>>[] includeProperties)
        {
            IQueryable<NOTICIASXCONDICION> query = context.NOTICIASXCONDICION;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public NOTICIASXCONDICION Find(int id)
        {
            return context.NOTICIASXCONDICION.Find(id);
        }

        public void InsertOrUpdate(NOTICIASXCONDICION noticiasxcondicion)
        {
            if (noticiasxcondicion.ID == default(int)) {
                // New entity
                context.NOTICIASXCONDICION.Add(noticiasxcondicion);
            } else {
                // Existing entity
                context.Entry(noticiasxcondicion).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var noticiasxcondicion = context.NOTICIASXCONDICION.Find(id);
            context.NOTICIASXCONDICION.Remove(noticiasxcondicion);
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

    public interface INOTICIASXCONDICIONRepository : IDisposable
    {
        IQueryable<NOTICIASXCONDICION> All { get; }
        IQueryable<NOTICIASXCONDICION> AllIncluding(params Expression<Func<NOTICIASXCONDICION, object>>[] includeProperties);
        NOTICIASXCONDICION Find(int id);
        void InsertOrUpdate(NOTICIASXCONDICION noticiasxcondicion);
        void Delete(int id);
        void Save();
    }
}