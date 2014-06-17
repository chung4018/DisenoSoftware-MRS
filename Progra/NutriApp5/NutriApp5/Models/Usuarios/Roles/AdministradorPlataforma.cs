using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nutriApp3.Models.Usuarios.Roles
{
    public class AdministradorPlataforma : RolUsuario
    {
        //Atributos

        //Constructor
        public AdministradorPlataforma()
        {

        }

        //Metodos
        public Boolean setRol()
        {
            return true;
        }

        public Boolean publicarNoticia()
        {
            return true;
        }

        public void crearComercio()
        {

        }
        public void modificarComercio()
        {

        }
        public void eliminarComercio()
        {

        }
        public void crearProducto()
        {

        }

        public void modificarProducto()
        {

        }
        public void eliminarProducto()
        {

        }
    }
}