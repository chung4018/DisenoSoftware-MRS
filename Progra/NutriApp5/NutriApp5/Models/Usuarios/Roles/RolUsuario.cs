using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NutriApp5.Models
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
        public abstract bool canPublishNotice();
        public abstract bool isAdmin();
        public virtual ICollection<int> getStoresAdmin()
        {
           
            return (new List<int>());
        
        }

        public virtual bool isAdminOf(int id)
        {
            
            return false;
        }
        public abstract bool isStoreAdmin();
    }
}