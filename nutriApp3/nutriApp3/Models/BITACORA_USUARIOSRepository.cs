using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace nutriApp3.Models
{ 
    public class BITACORA_USUARIOSRepository : IBITACORA_USUARIOSRepository
    {
        Entities context = new Entities();

        public IQueryable<BITACORA_USUARIOS> All
        {
            get { return context.BITACORA_USUARIOS; }
        }

        public IQueryable<BITACORA_USUARIOS> AllIncluding(params Expression<Func<BITACORA_USUARIOS, object>>[] includeProperties)
        {
            IQueryable<BITACORA_USUARIOS> query = context.BITACORA_USUARIOS;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public BITACORA_USUARIOS Find(int id)
        {
            return context.BITACORA_USUARIOS.Find(id);
        }

        public void InsertOrUpdate(BITACORA_USUARIOS bitacora_usuarios)
        {
            if (bitacora_usuarios.ID_BITACORA == default(int)) {
                // New entity
                context.BITACORA_USUARIOS.Add(bitacora_usuarios);
            } else {
                // Existing entity
                context.Entry(bitacora_usuarios).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var bitacora_usuarios = context.BITACORA_USUARIOS.Find(id);
            context.BITACORA_USUARIOS.Remove(bitacora_usuarios);
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

    public interface IBITACORA_USUARIOSRepository : IDisposable
    {
        IQueryable<BITACORA_USUARIOS> All { get; }
        IQueryable<BITACORA_USUARIOS> AllIncluding(params Expression<Func<BITACORA_USUARIOS, object>>[] includeProperties);
        BITACORA_USUARIOS Find(int id);
        void InsertOrUpdate(BITACORA_USUARIOS bitacora_usuarios);
        void Delete(int id);
        void Save();
    }
}