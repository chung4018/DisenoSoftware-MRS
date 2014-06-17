using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nutriApp3.Models
{
    public abstract class RolUsuario
    {
        private String nombreRol;


        //Getters and Setters
        public String NombreRol
        {
            get { return nombreRol; }
            set { nombreRol = value; }
        }
    }
}