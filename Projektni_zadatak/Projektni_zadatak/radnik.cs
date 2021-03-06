//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class radnik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public radnik()
        {
            this.sati_bolovanja = new HashSet<sati_bolovanja>();
            this.sati_godisnji = new HashSet<sati_godisnji>();
            this.radni_sati = new HashSet<radni_sati>();
            this.sati_blagdani = new HashSet<sati_blagdani>();
        }
    
        public int ID_radnik { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public Nullable<int> OIB { get; set; }
        public string adresa { get; set; }
        public string broj_racuna { get; set; }
        public string banka { get; set; }
        public Nullable<int> placa_ID { get; set; }
        public Nullable<int> odbitakZaDjecu_ID { get; set; }
        public Nullable<int> odbitakClanovi_ID { get; set; }
        public string poslodavac_ID { get; set; }
    
        public virtual poslodavac poslodavac { get; set; }
        public virtual odbitak_za_djecu odbitak_za_djecu { get; set; }
        public virtual placa placa { get; set; }
        public virtual odbitak_clanovi odbitak_clanovi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sati_bolovanja> sati_bolovanja { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sati_godisnji> sati_godisnji { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<radni_sati> radni_sati { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sati_blagdani> sati_blagdani { get; set; }
    }
}
