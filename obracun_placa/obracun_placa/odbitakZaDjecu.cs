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
    using System.ComponentModel;
    using System.Linq;

    public partial class odbitakZaDjecu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public odbitakZaDjecu()
        {
            this.radnik = new HashSet<radnik>();
        }
    
        public int ID_odbitakDjeca { get; set; }
        public string broj_djece { get; set; }
        public Nullable<double> koeficijent { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<radnik> radnik { get; set; }

        public BindingList<odbitakZaDjecu> vratiDjecu() {

            BindingList<odbitakZaDjecu> lista = null;
            using (var db = new PlaceEntities4()) {

                lista = new BindingList<odbitakZaDjecu>(db.odbitakZaDjecu.ToList());
            }
            return lista;

        }
    }
}
