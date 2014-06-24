using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace NutriApp5.Models
{ 
    public class ROLESRepository : IROLESRepository
    {
        Entities context = new Entities();

        public IQueryable<ROLES> All
        {
            get { return context.ROLES; }
        }

        public IQueryable<ROLES> AllIncluding(params Expression<Func<ROLES, object>>[] includeProperties)
        {
            IQueryable<ROLES> query = context.ROLES;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public ROLES Find(decimal id)
        {
            return context.ROLES.Find(id);
        }

        public void InsertOrUpdate(ROLES roles)
        {
            if (roles.ID_ROL == default(decimal)) {
                // New entity
                context.ROLES.Add(roles);
            } else {
                // Existing entity
                context.Entry(roles).State = EntityState.Modified;
            }
        }

        public void Delete(decimal id)
        {
            var roles = context.ROLES.Find(id);
            context.ROLES.Remove(roles);
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

    public interface IROLESRepository : IDisposable
    {
        IQueryable<ROLES> All { get; }
        IQueryable<ROLES> AllIncluding(params Expression<Func<ROLES, object>>[] includeProperties);
        ROLES Find(decimal id);
        void InsertOrUpdate(ROLES roles);
        void Delete(decimal id);
        void Save();
    }
}