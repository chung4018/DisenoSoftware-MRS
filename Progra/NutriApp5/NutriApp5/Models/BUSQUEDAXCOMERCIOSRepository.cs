using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace NutriApp5.Models
{ 
    public class BUSQUEDAXCOMERCIOSRepository : IBUSQUEDAXCOMERCIOSRepository
    {
        Entities context = new Entities();

        public IQueryable<BUSQUEDAXCOMERCIOS> All
        {
            get { return context.BUSQUEDAXCOMERCIOS; }
        }

        public IQueryable<BUSQUEDAXCOMERCIOS> AllIncluding(params Expression<Func<BUSQUEDAXCOMERCIOS, object>>[] includeProperties)
        {
            IQueryable<BUSQUEDAXCOMERCIOS> query = context.BUSQUEDAXCOMERCIOS;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public BUSQUEDAXCOMERCIOS Find(int id)
        {
            return context.BUSQUEDAXCOMERCIOS.Find(id);
        }

        public void InsertOrUpdate(BUSQUEDAXCOMERCIOS busquedaxcomercios)
        {
            if (busquedaxcomercios.ID == default(int)) {
                // New entity
                context.BUSQUEDAXCOMERCIOS.Add(busquedaxcomercios);
            } else {
                // Existing entity
                context.Entry(busquedaxcomercios).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var busquedaxcomercios = context.BUSQUEDAXCOMERCIOS.Find(id);
            context.BUSQUEDAXCOMERCIOS.Remove(busquedaxcomercios);
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

    public interface IBUSQUEDAXCOMERCIOSRepository : IDisposable
    {
        IQueryable<BUSQUEDAXCOMERCIOS> All { get; }
        IQueryable<BUSQUEDAXCOMERCIOS> AllIncluding(params Expression<Func<BUSQUEDAXCOMERCIOS, object>>[] includeProperties);
        BUSQUEDAXCOMERCIOS Find(int id);
        void InsertOrUpdate(BUSQUEDAXCOMERCIOS busquedaxcomercios);
        void Delete(int id);
        void Save();
    }
}