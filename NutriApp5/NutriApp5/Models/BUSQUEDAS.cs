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
    using System.ComponentModel.DataAnnotations;
    
    public partial class BUSQUEDAS
    {
        public BUSQUEDAS()
        {
            this.BUSQUEDAXCOMERCIOS = new HashSet<BUSQUEDAXCOMERCIOS>();
            this.BUSQUEDAXPRODUCTOS = new HashSet<BUSQUEDAXPRODUCTOS>();
        }
        [Key]
        public int ID_BUSQUEDA { get; set; }
        public Nullable<int> ID_USUARIO { get; set; }
        public Nullable<System.DateTime> FECHA_HORA { get; set; }
    
        public virtual USUARIOS USUARIOS { get; set; }
        public virtual ICollection<BUSQUEDAXCOMERCIOS> BUSQUEDAXCOMERCIOS { get; set; }
        public virtual ICollection<BUSQUEDAXPRODUCTOS> BUSQUEDAXPRODUCTOS { get; set; }
    }
}