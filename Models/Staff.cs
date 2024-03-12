using System; 
using System.Collections.Generic;

namespace doan.Models
{
    public partial class Staff

    {
        public Staff()
        {
            Dondathang = new HashSet<PurchaseOrder>();
        }

        public int MaNv { get; set; }
        public string TenNv { get; set; }
        public string SoDienThoai { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgayVaoLam { get; set; }
        public string ChucVu { get; set; }

        public virtual ICollection<PurchaseOrder> Dondathang { get; set; }
    }
}
