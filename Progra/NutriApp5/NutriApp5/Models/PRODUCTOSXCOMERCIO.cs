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
    
    public partial class PRODUCTOSXCOMERCIO
    {
        public int ID { get; set; }
        public int ID_COMERCIO { get; set; }
        public int ID_PRODUCTO { get; set; }
    
        public virtual COMERCIOS COMERCIOS { get; set; }
        public virtual PRODUCTOS PRODUCTOS { get; set; }
    }
}
