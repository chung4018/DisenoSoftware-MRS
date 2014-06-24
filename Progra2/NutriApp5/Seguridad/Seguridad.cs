using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nutriApp3.Models;
using NutriApp5.Models;

namespace NutriApp5.Seguridad
{
    public class Seguridad
    {
        LoginControl loginInfo = LoginControl.Instance;
        private static Seguridad instance;

        private Seguridad() { }

        public static Seguridad Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Seguridad();
                }
                return instance;
            }
        }

        public bool canPublishNotice()
        {
            bool result = false;
            ICollection<RolUsuario> rolesUser = LoginControl.Instance.objUsuario.RolesUsuario;
            foreach (var rol in rolesUser)
            {
                result = rol.canPublishNotice();
                if (result)
                    break;
            }
            return result;

        }
        public bool isAdmin()
        {
            bool result = false;
            ICollection<RolUsuario> rolesUser = LoginControl.Instance.objUsuario.RolesUsuario;
            foreach (var rol in rolesUser)
            {
                result = rol.isAdmin();
                if (result)
                    break;
            }
            return result;

        }
        public bool isStoreAdmin()
        {
            bool result = false;
            ICollection<RolUsuario> rolesUser = LoginControl.Instance.objUsuario.RolesUsuario;
            foreach (var rol in rolesUser)
            {
                result = rol.isStoreAdmin();
                if (result)
                    break;
            }
            return result;

        }
        public ICollection<int> getStoresAdmin(int idUsuario)
        {
            ICollection<int> result = new List<int>();
            ICollection<RolUsuario> rolesUser = LoginControl.Instance.objUsuario.RolesUsuario;
            foreach (var rol in rolesUser)
            {
                if (rol.isStoreAdmin())
                {
                    result = rol.getStoresAdmin();
                    break;
                }
            }
            return result;
        }


        public bool isAdminOf(int idComercio)
        {
            bool result = false;
            ICollection<RolUsuario> rolesUser = LoginControl.Instance.objUsuario.RolesUsuario;
            foreach (var rol in rolesUser)
            {
                if (rol.isStoreAdmin())
                {
                    result = rol.isAdminOf(idComercio);
                    break;
                }
            }
            return result;
        }
    }
}