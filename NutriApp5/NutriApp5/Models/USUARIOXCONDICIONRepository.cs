using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace NutriApp5.Models
{ 
    public class USUARIOXCONDICIONRepository : IUSUARIOXCONDICIONRepository
    {
        Entities context = new Entities();

        public IQueryable<USUARIOXCONDICION> All
        {
            get { return context.USUARIOXCONDICION; }
        }

        public IQueryable<USUARIOXCONDICION> AllIncluding(params Expression<Func<USUARIOXCONDICION, object>>[] includeProperties)
        {
            IQueryable<USUARIOXCONDICION> query = context.USUARIOXCONDICION;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public USUARIOXCONDICION Find(int id)
        {
            return context.USUARIOXCONDICION.Find(id);
        }

        public void InsertOrUpdate(USUARIOXCONDICION usuarioxcondicion)
        {
            if (usuarioxcondicion.ID == default(int)) {
                // New entity
                usuarioxcondicion.ID = getLastNumber()+1;
                context.USUARIOXCONDICION.Add(usuarioxcondicion);
                context.SaveChanges();
            } else {
                // Existing entity
                context.Entry(usuarioxcondicion).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var usuarioxcondicion = context.USUARIOXCONDICION.Find(id);
            context.USUARIOXCONDICION.Remove(usuarioxcondicion);
        }
        public void DeleteAllCondicionesUser(int idUser)
        {
            IQueryable<USUARIOXCONDICION> condiciones = (from USUARIOXCONDICION p in context.USUARIOXCONDICION
                                               where p.ID_USUARIO == idUser
                                               select p);
            foreach (var condicion in condiciones)
            {
                this.Delete(condicion.ID);
            }
            this.Save();
        }

        //recupera el ultimo registro de la base de datos  para los usuarios
        private int getLastNumber()
        {
            int resp = 0;
            IQueryable<USUARIOXCONDICION> condiciones = (from USUARIOXCONDICION p in context.USUARIOXCONDICION
                                               select p);
            foreach (var condicion in condiciones)
            {
                resp = condicion.ID;
            }

            return resp;
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

    public interface IUSUARIOXCONDICIONRepository : IDisposable
    {
        IQueryable<USUARIOXCONDICION> All { get; }
        IQueryable<USUARIOXCONDICION> AllIncluding(params Expression<Func<USUARIOXCONDICION, object>>[] includeProperties);
        USUARIOXCONDICION Find(int id);
        void DeleteAllCondicionesUser(int idUser);
        void InsertOrUpdate(USUARIOXCONDICION usuarioxcondicion);
        void Delete(int id);
        void Save();
    }
}