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
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public ROLESXUSUARIO Find(int id)
        {
            return context.ROLESXUSUARIO.Find(id);
        }

        public ICollection<ROLES> getRolesByUser(int id)
        {
            IQueryable<ROLESXUSUARIO> query = (from ROLESXUSUARIO p in context.ROLESXUSUARIO
                                               where p.ID_USUARIO == id
                                               select p);
            ICollection<ROLES> listaRoles = new List<ROLES>();
            foreach (var rol in query)
            {
                ROLES rolNuevo = (new ROLESRepository()).Find(rol.ID_ROL);

                listaRoles.Add(rolNuevo);
            }
            return listaRoles;
        }

        public ICollection<CONDICION> getCondicionByUser(int id)
        {
            IQueryable<USUARIOXCONDICION> query = (from USUARIOXCONDICION p in context.USUARIOXCONDICION
                                               where p.ID_USUARIO == id
                                               select p);
            ICollection<CONDICION> listaCondiciones= new List<CONDICION>();
            foreach (var condicion in query)
            {
                CONDICION condicinoNueva = (new CONDICIONRepository()).Find(condicion.ID_CONDICION);

                listaCondiciones.Add(condicinoNueva);
            }
            return listaCondiciones;
        }
        public void InsertOrUpdate(ROLESXUSUARIO rolesxusuario)
        {
            if (rolesxusuario.ID == default(int))
            {
                // New entity
                rolesxusuario.ID = getLastNumber() + 1;
                context.ROLESXUSUARIO.Add(rolesxusuario);
            }
            else
            {
                // Existing entity
                context.Entry(rolesxusuario).State = EntityState.Modified;
            }
        }
        //recupera el ultimo registro de la base de datos  para los usuarios
        private int getLastNumber()
        {
            int resp = 0;
            IQueryable<ROLESXUSUARIO> roles = (from ROLESXUSUARIO p in context.ROLESXUSUARIO
                                               select p);
            foreach (var rol in roles)
            {
                resp = rol.ID;
            }

            return resp;
        }

        public void Delete(int id)
        {
            var rolesxusuario = context.ROLESXUSUARIO.Find(id);
            context.ROLESXUSUARIO.Remove(rolesxusuario);
        }

        public void DeleteAllRolesUser(int idUser)
        {
            IQueryable<ROLESXUSUARIO> roles = (from ROLESXUSUARIO p in context.ROLESXUSUARIO
                                               where p.ID_USUARIO == idUser
                                               select p);
            foreach (var rol in roles)
            {
                this.Delete(rol.ID);
            }
            this.Save();
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
        ICollection<ROLES> getRolesByUser(int id);
        ICollection<CONDICION> getCondicionByUser(int id);
        void DeleteAllRolesUser(int idUser);
        void InsertOrUpdate(ROLESXUSUARIO rolesxusuario);
        void Delete(int id);
        void Save();
    }
}