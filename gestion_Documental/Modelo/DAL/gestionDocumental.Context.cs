﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace gestion_Documental.Modelo.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class gestiondocumentalEntities : DbContext
    {
        public gestiondocumentalEntities()
            : base("name=gestiondocumentalEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<centroeducativo> centroeducativo { get; set; }
        public DbSet<centrotrabajo> centrotrabajo { get; set; }
        public DbSet<documentos> documentos { get; set; }
        public DbSet<empresa> empresa { get; set; }
        public DbSet<permisos> permisos { get; set; }
        public DbSet<responsable> responsable { get; set; }
        public DbSet<rol> rol { get; set; }
        public DbSet<usuarios> usuarios { get; set; }
    }
}
