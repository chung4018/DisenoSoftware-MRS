//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NutriApp5.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ROLES
    {
        public ROLES()
        {
            this.ROLESXUSUARIO = new HashSet<ROLESXUSUARIO>();
        }
    
        public decimal ID_ROL { get; set; }
        public string NOMBRE { get; set; }
    
        public virtual ICollection<ROLESXUSUARIO> ROLESXUSUARIO { get; set; }
    }
}
