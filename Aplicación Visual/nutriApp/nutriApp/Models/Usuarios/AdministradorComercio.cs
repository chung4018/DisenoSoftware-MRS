using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nutriApp.Models.Usuarios
{
    public class AdministradorComercio : RolUsuario
    {
        //Atributos
        private String[] comerciosAsociados;

      

        //constructor 
        public AdministradorComercio()
        {

        }
        //Metodos 
        public Boolean addProducto(String idProducto)
        {
            return true;

        }
        public Boolean removeProducto(String idProducto)
        {
            return true;

        }
        public Boolean modificarComercio()
        {
            return true;

        }
        public Boolean eliminarComercio()
        {
            return true;

        }

        //Getters and Setters
        public String[] ComerciosAsociados
        {
            get { return comerciosAsociados; }
            set { comerciosAsociados = value; }
        }
    }
}