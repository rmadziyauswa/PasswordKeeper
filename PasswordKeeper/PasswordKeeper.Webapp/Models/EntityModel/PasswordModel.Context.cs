﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PasswordKeeper.Webapp.Models.EntityModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PaswordEntities : DbContext
    {
        public PaswordEntities()
            : base("name=PaswordEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Credential> Credentials { get; set; }
        public virtual DbSet<CredentialType> CredentialTypes { get; set; }
        public virtual DbSet<Host> Hosts { get; set; }
        public virtual DbSet<HostType> HostTypes { get; set; }
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
    }
}
