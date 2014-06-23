using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NutriApp5.Models.Usuarios.Roles
{
    public class Comun : RolUsuario
    {
        //Constructor
        public Comun()
        {

        }
        public override bool canPublishNotice()
        {
            return false;
        }
        public override bool isAdmin()
        {
            return false;
        }
        public override bool isStoreAdmin()
        {
            return false;
        }
        
    }
}