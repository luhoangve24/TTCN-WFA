//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AjumaShop.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            this.DonDatHangs = new HashSet<DonDatHang>();
        }
    
        public string makhach { get; set; }
        public string tenkhach { get; set; }
        public string sdt { get; set; }
        public string diachichitiet { get; set; }
        public Nullable<int> maxaphuong { get; set; }
        public Nullable<System.DateTime> ngaysinh { get; set; }
        public string linkfacebook { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonDatHang> DonDatHangs { get; set; }
        public virtual XaPhuong XaPhuong { get; set; }
    }
}