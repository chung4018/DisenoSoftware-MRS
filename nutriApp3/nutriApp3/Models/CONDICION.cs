//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace nutriApp3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class CONDICION
    {
        public CONDICION()
        {
            this.NOTICIAS = new HashSet<NOTICIAS>();
            this.USUARIOS = new HashSet<USUARIOS>();
        }
        [Key]
        public decimal ID_CONDICION { get; set; }
        public string NOMBRE { get; set; }
        public string INFORMACION_CONDICION { get; set; }
    
        public virtual ICollection<NOTICIAS> NOTICIAS { get; set; }
        public virtual ICollection<USUARIOS> USUARIOS { get; set; }
    }
}
