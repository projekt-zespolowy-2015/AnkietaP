﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AnkietaP.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AnkietaEntities3 : DbContext
    {
        public AnkietaEntities3()
            : base("name=AnkietaEntities3")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<adre> adres { get; set; }
        public virtual DbSet<ankieta> ankietas { get; set; }
        public virtual DbSet<kategoria_pytania> kategoria_pytania { get; set; }
        public virtual DbSet<localadmin> localadmins { get; set; }
        public virtual DbSet<miejscowosc> miejscowoscs { get; set; }
        public virtual DbSet<mieszkaniec> mieszkaniecs { get; set; }
        public virtual DbSet<opcje> opcjes { get; set; }
        public virtual DbSet<powiat_gmina> powiat_gmina { get; set; }
        public virtual DbSet<pytanie> pytanies { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<ulica> ulicas { get; set; }
        public virtual DbSet<wynik_bool> wynik_bool { get; set; }
        public virtual DbSet<wynik_lista> wynik_lista { get; set; }
    }
}
