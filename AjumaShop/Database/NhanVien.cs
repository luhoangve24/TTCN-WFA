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
    
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            this.DonDatHangs = new HashSet<DonDatHang>();
            this.DonNhapHangs = new HashSet<DonNhapHang>();
        }
    
        public string manhanvien { get; set; }
        public string tennhanvien { get; set; }
        public string gioitinh { get; set; }
        public Nullable<System.DateTime> ngaysinh { get; set; }
        public string sdt { get; set; }
        public string email { get; set; }
        public string linkfacebook { get; set; }
        public string diachi { get; set; }
        public string machucvu { get; set; }
    
        public virtual ChucVu ChucVu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonDatHang> DonDatHangs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonNhapHang> DonNhapHangs { get; set; }
    }
}
