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

    public partial class odbitakClan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public odbitakClan()
        {
            this.radnik = new HashSet<radnik>();
        }
    
        public int ID_odbitakClan { get; set; }
        public string broj_clanova { get; set; }
        public Nullable<double> koeficijent { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<radnik> radnik { get; set; }
        public BindingList<odbitakClan> vratiClan()
        {

            BindingList<odbitakClan> lista = null;
            using (var db = new PlaceEntities4())
            {
                lista = new BindingList<odbitakClan>(db.odbitakClan.ToList());

            }
            return lista;

        }

    }
}
