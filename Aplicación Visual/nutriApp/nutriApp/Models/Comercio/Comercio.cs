using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nutriApp.Models.Comercio
{
    public class Comercio
    {
        //Atributos
        private String nombreComercio;     
        private int[] coordenadasGeograficas;       
        private String tipoComercio;
        private int telefono;
        private String correoElectronico;

       
        //Constructor
        public Comercio()
        {


        }

        //Metodos
        public void getProductos(String[] producto)
        {


        }

        //Getters and Setters
        public String NombreComercio
        {
            get { return nombreComercio; }
            set { nombreComercio = value; }
        }

        public int[] Geoxy
        {
            get { return coordenadasGeograficas = new int[2]; }
            set { coordenadasGeograficas = value; }
        }

        public String TipoComercio
        {
            get { return tipoComercio; }
            set { tipoComercio = value; }
        }

        public int telComercio
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public String correoComercio
        {
            get { return correoElectronico; }
            set { correoElectronico = value; }
        }
    }
}