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
    
    public partial class placa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public placa()
        {
            this.doprinosIZ = new HashSet<doprinosIZ>();
            this.doprinosNA = new HashSet<doprinosNA>();
            this.obracun_placa = new HashSet<obracun_placa>();
        }
    
        public int ID_placa { get; set; }
        public Nullable<int> visina { get; set; }
        public string vrsta { get; set; }
        public Nullable<int> ukupno_bruto { get; set; }
        public Nullable<int> ukupno_neto { get; set; }
        public Nullable<int> ukupno_trosak { get; set; }
        public Nullable<int> dohodak { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<doprinosIZ> doprinosIZ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<doprinosNA> doprinosNA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<obracun_placa> obracun_placa { get; set; }
        public virtual prirez prirez { get; set; }
        public virtual radnik radnik { get; set; }
    }
}