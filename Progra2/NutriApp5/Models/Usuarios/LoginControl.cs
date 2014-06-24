using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NutriApp5.Models;

namespace NutriApp5.Models
{
    public class LoginControl
    {
        private static LoginControl instance;
        private bool loginActive = false; 

        public bool LoginActive
        {
          get { return loginActive; }
          set { loginActive = value; }
        }
        public string LogedUserName { get; set; }
        public int idLogedUser { get; set; }
        public USUARIOS objUsuario { get; set; }

        private LoginControl() { }

        public static LoginControl Instance
        {
          get 
          {
             if (instance == null)
             {
                 instance = new LoginControl();
                 
             }
             return instance;
          }
       }

    }
}