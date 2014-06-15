using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nutriApp.Models.Producto
{
    public class Producto
    {
        //Atributos
        private String nombreProducto;     
        private String informacionNutricional;

       
        //Constructor
        public Producto()
        {


        }

        //Metodos
        public void getComerciosVendedores(String comercio)
        {


        }

        //Getters and Setters
        public String NombreProducto
        {
            get { return nombreProducto; }
            set { nombreProducto = value; }
        }

        public String nutricion
        {
            get { return informacionNutricional; }
            set { informacionNutricional = value; }
        }

    }
}