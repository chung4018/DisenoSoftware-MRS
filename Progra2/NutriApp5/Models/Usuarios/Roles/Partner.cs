using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NutriApp5.Models.Usuarios.Roles
{
    public class Partner : RolUsuario
    {
        //Atributos


        //constructor 
        public Partner()
        {

        }

        //Metodos
        
        public override bool canPublishNotice()
        {
            return true;
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