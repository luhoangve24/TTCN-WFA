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
    
    public partial class DonDatHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonDatHang()
        {
            this.ChiTietDonDatHangs = new HashSet<ChiTietDonDatHang>();
        }
    
        public string madondathang { get; set; }
        public System.DateTime ngaydathang { get; set; }
        public double tongsanpham { get; set; }
        public double tongtien { get; set; }
        public string phuongthucthanhtoan { get; set; }
        public Nullable<double> sotiendathanhtoan { get; set; }
        public string diachinhanhang { get; set; }
        public string trangthai { get; set; }
        public string mavandon { get; set; }
        public string ghichu { get; set; }
        public string makhach { get; set; }
        public string manhanvien { get; set; }
        public double tongtrongluong_ { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonDatHang> ChiTietDonDatHangs { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}