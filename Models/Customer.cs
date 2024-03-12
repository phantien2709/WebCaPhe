using System; 
using System.Collections.Generic;

namespace doan.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Dondathang = new HashSet<PurchaseOrder>();
        }

        public int MaKh { get; set; }
        public string TenKh { get; set; }
        public string SoDienThoai { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string LoaiKh { get; set; }

        public virtual ICollection<PurchaseOrder> Dondathang { get; set; }
    }
}
