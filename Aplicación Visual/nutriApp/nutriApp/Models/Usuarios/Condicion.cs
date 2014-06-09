using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nutriApp.Models
{
    public class Condicion
    {
        //Atributos
        private String nombre;
        private String infoCondicion;//contiene una descripcion de la condicion, en que consiste, etc

       
        //Constructor
        public Condicion()
        {

        }
        //Metodos

        //Getters and Setters
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public String InfoCondicion
        {
            get { return infoCondicion; }
            set { infoCondicion = value; }
        }


    }
}