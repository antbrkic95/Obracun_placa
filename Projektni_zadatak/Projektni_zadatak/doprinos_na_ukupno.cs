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
    
    public partial class doprinos_na_ukupno
    {
        public int ID_doprinosNaUkupno { get; set; }
        public string naziv { get; set; }
        public Nullable<int> koeficijent { get; set; }
        public Nullable<int> placa_ID { get; set; }
    
        public virtual placa placa { get; set; }
    }
}
