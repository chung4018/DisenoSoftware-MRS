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
    
    public partial class NOTICIASXCONDICION
    {
        public int ID { get; set; }
        public decimal ID_CONDICION { get; set; }
        public int ID_NOTICIA { get; set; }
    
        public virtual CONDICION CONDICION { get; set; }
        public virtual NOTICIAS NOTICIAS { get; set; }
    }
}
