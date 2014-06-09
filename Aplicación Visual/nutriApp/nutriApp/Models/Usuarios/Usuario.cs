using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nutriApp.Models.Usuarios
{
    public class Usuario
    {
        //Atributos
        private String nombre;     
        private String correo;       
        private RolUsuario[] roles;

       
        //Constructor
        public Usuario()
        {


        }

        //Metodos
        public void eliminarUsuario()
        {


        }
        public Boolean modificarUsuario()
        {
            return true;
            
        }

        public void buscarComercios (String condicion)
        {


        }
        public void buscarProductos(String condicion)
        {


        }

        //Getters and Setters
        public RolUsuario[] Roles
        {
            get { return roles; }
            set { roles = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public String Correo
        {
            get { return correo; }
            set { correo = value; }
        }
    }
}