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
    
    public partial class sati_blagdani
    {
        public int ID_blagdani { get; set; }
        public string naziv { get; set; }
        public Nullable<int> broj_sati { get; set; }
    
        public virtual radnik radnik { get; set; }
    }
}
