﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nutriApp3.Models.Usuarios.Roles
{
    public class Partner : RolUsuario
    {
        //Atributos


        //constructor 
        public Partner()
        {

        }

        //Metodos
        public Boolean publicarNoticia()
        {
            return true;
        }
    }
}