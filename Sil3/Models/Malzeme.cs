//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sil3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Malzeme
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Malzeme()
        {
            this.StokGiris = new HashSet<StokGiris>();
        }
    
        public int Id { get; set; }
        public decimal Kod { get; set; }
        public string Ad { get; set; }
        public decimal Barkod { get; set; }
        public int GrupId { get; set; }
        public int BirimId { get; set; }
        public decimal KdvOrani { get; set; }
    
        public virtual Birim Birim { get; set; }
        public virtual Grup Grup { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StokGiris> StokGiris { get; set; }
    }
}
