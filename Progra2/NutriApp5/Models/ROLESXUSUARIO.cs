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
    
    public partial class ROLESXUSUARIO
    {
        public int ID { get; set; }
        public int ID_USUARIO { get; set; }
        public decimal ID_ROL { get; set; }
    
        public virtual ROLES ROLES { get; set; }
        public virtual USUARIOS USUARIOS { get; set; }
    }
}
