using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace NutriApp5.Models
{
    public class USUARIOSRepository : IUSUARIOSRepository
    {
        Entities context = new Entities();

        private readonly IROLESXUSUARIORepository rolesXusuarioRepository = new ROLESXUSUARIORepository();

        public IQueryable<USUARIOS> All
        {
            get { return context.USUARIOS; }
        }

        public IQueryable<USUARIOS> AllIncluding(params Expression<Func<USUARIOS, object>>[] includeProperties)
        {
            IQueryable<USUARIOS> query = context.USUARIOS;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public USUARIOS Find(int id)
        {
            USUARIOS user = context.USUARIOS.Find(id);

            user.ROLES = rolesXusuarioRepository.getRolesByUser(id);
            user.CONDICIONES = rolesXusuarioRepository.getCondicionByUser(id);
            return user;
        }

        public ICollection<ROLES> getUserRoles(int id)
        {
            ICollection<ROLES> listaRoles = rolesXusuarioRepository.getRolesByUser(id);
            return listaRoles;
        }

        public void InsertOrUpdate(USUARIOS usuarios)
        {
            if (usuarios.ID_USUARIO == default(int))
            {
                // New entity
                usuarios.ID_USUARIO = getLastNumber() + 1;
                context.USUARIOS.Add(usuarios);
                context.SaveChanges();
            }
            else
            {
                // Existing entity
                context.Entry(usuarios).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var usuarios = context.USUARIOS.Find(id);
            context.USUARIOS.Remove(usuarios);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public USUARIOS getUserByEmail(string email)
        {
            USUARIOS user = (from USUARIOS p in context.USUARIOS
                             where p.CORREO == email
                             select p).FirstOrDefault();
            return user;

        }
        //recupera el ultimo registro de la base de datos  para los usuarios
        private int getLastNumber()
        {
            int resp = 0;
            IQueryable<USUARIOS> users = (from USUARIOS p in context.USUARIOS
                                          select p);
            foreach (var user in users)
            {
                resp = user.ID_USUARIO;
            }

            return resp;
        }
    }

    public interface IUSUARIOSRepository : IDisposable
    {
        IQueryable<USUARIOS> All { get; }
        IQueryable<USUARIOS> AllIncluding(params Expression<Func<USUARIOS, object>>[] includeProperties);
        USUARIOS Find(int id);
        USUARIOS getUserByEmail(string email);
        void InsertOrUpdate(USUARIOS usuarios);
        void Delete(int id);
        void Save();
    }
}