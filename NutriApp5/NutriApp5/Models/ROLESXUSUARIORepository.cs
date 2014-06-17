using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace NutriApp5.Models
{ 
    public class ROLESXUSUARIORepository : IROLESXUSUARIORepository
    {
        Entities context = new Entities();

        public IQueryable<ROLESXUSUARIO> All
        {
            get { return context.ROLESXUSUARIO; }
        }

        public IQueryable<ROLESXUSUARIO> AllIncluding(params Expression<Func<ROLESXUSUARIO, object>>[] includeProperties)
        {
            IQueryable<ROLESXUSUARIO> query = context.ROLESXUSUARIO;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public ROLESXUSUARIO Find(int id)
        {
            return context.ROLESXUSUARIO.Find(id);
        }

        public void InsertOrUpdate(ROLESXUSUARIO rolesxusuario)
        {
            if (rolesxusuario.ID == default(int)) {
                // New entity
                context.ROLESXUSUARIO.Add(rolesxusuario);
            } else {
                // Existing entity
                context.Entry(rolesxusuario).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var rolesxusuario = context.ROLESXUSUARIO.Find(id);
            context.ROLESXUSUARIO.Remove(rolesxusuario);
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

    public interface IROLESXUSUARIORepository : IDisposable
    {
        IQueryable<ROLESXUSUARIO> All { get; }
        IQueryable<ROLESXUSUARIO> AllIncluding(params Expression<Func<ROLESXUSUARIO, object>>[] includeProperties);
        ROLESXUSUARIO Find(int id);
        void InsertOrUpdate(ROLESXUSUARIO rolesxusuario);
        void Delete(int id);
        void Save();
    }
}