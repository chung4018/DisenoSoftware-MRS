﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<BITACORA_COMERCIO> BITACORA_COMERCIO { get; set; }
        public DbSet<BITACORA_NOTICIAS> BITACORA_NOTICIAS { get; set; }
        public DbSet<BITACORA_PRODUCTOS> BITACORA_PRODUCTOS { get; set; }
        public DbSet<BITACORA_USUARIOS> BITACORA_USUARIOS { get; set; }
        public DbSet<BUSQUEDAS> BUSQUEDAS { get; set; }
        public DbSet<COMERCIOS> COMERCIOS { get; set; }
        public DbSet<CONDICION> CONDICION { get; set; }
        public DbSet<NOTICIAS> NOTICIAS { get; set; }
        public DbSet<PRODUCTOS> PRODUCTOS { get; set; }
        public DbSet<ROLES> ROLES { get; set; }
        public DbSet<TIPO_COMERCIO> TIPO_COMERCIO { get; set; }
        public DbSet<TIPO_INFORMACION> TIPO_INFORMACION { get; set; }
        public DbSet<TIPO_PRODUCTO> TIPO_PRODUCTO { get; set; }
        public DbSet<USUARIOS> USUARIOS { get; set; }
    }
}