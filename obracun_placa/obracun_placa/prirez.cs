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

    public partial class prirez
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public prirez()
        {
            this.placa = new HashSet<placa>();
        }
    
        public int ID_prirez { get; set; }
        public string opcina { get; set; }
        public Nullable<int> postotak { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<placa> placa { get; set; }

        public BindingList<prirez> vratiPrirez()
        {

            BindingList<prirez> lista = null;
            using (var db = new PlaceEntities4())
            {
                lista = new BindingList<prirez>(db.prirez.ToList());

            }
            return lista;

        }
    }
}
