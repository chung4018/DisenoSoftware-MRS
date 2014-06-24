using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NutriApp5.Models.Usuarios.Roles
{
    public class AdministradorPlataforma : RolUsuario
    {
        //Atributos

        //Constructor
        public AdministradorPlataforma()
        {

        }

        //Metodos
        public override bool canPublishNotice()
        {
            return true;
        }
        public override bool isAdmin()
        {
            return true;
        }
        public override bool isStoreAdmin()
        {
            return true;
        }
        
    }
}