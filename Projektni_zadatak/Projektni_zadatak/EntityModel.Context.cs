﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Projektni_zadatak
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ProjektEntities : DbContext
    {
        public ProjektEntities()
            : base("name=ProjektEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<doprinos_iz_ukupno> doprinos_iz_ukupno { get; set; }
        public virtual DbSet<doprinos_na_ukupno> doprinos_na_ukupno { get; set; }
        public virtual DbSet<obracun_placa> obracun_placa { get; set; }
        public virtual DbSet<odbitak_clanovi> odbitak_clanovi { get; set; }
        public virtual DbSet<odbitak_za_djecu> odbitak_za_djecu { get; set; }
        public virtual DbSet<placa> placa { get; set; }
        public virtual DbSet<poslodavac> poslodavac { get; set; }
        public virtual DbSet<prirez> prirez { get; set; }
        public virtual DbSet<radni_sati> radni_sati { get; set; }
        public virtual DbSet<radnik> radnik { get; set; }
        public virtual DbSet<sati_blagdani> sati_blagdani { get; set; }
        public virtual DbSet<sati_bolovanja> sati_bolovanja { get; set; }
        public virtual DbSet<sati_godisnji> sati_godisnji { get; set; }
        public virtual DbSet<stanje> stanje { get; set; }
    }
}
