//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace obracun_placa
{
    using System;
    using System.Collections.Generic;
    
    public partial class radnik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public radnik()
        {
            this.placa = new HashSet<placa>();
            this.radniSati = new HashSet<radniSati>();
            this.sati_blagdani = new HashSet<sati_blagdani>();
            this.sati_bolovanje = new HashSet<sati_bolovanje>();
            this.sati_godisnji = new HashSet<sati_godisnji>();
        }
    
        public int ID_radnik { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string OIB { get; set; }
        public string broj_telefona { get; set; }
        public string broj_racuna { get; set; }
        public string banka { get; set; }
        public string adresa { get; set; }
    
        public virtual odbitakClan odbitakClan { get; set; }
        public virtual odbitakZaDjecu odbitakZaDjecu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<placa> placa { get; set; }
        public virtual poslodavac poslodavac { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<radniSati> radniSati { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sati_blagdani> sati_blagdani { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sati_bolovanje> sati_bolovanje { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sati_godisnji> sati_godisnji { get; set; }
    }
}
