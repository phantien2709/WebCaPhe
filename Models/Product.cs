using System;
using System.Collections.Generic; 

namespace doan.Models
{
    public partial class Product
    {
        public Product()
        {
            Hinhanh = new HashSet<Image>();
        }

        public int MaSp { get; set; }
        public string TenSp { get; set; }
        public decimal? GiaTien { get; set; }
        public int SoLuong { get; set; }
        public int MaDanhMuc { get; set; }
        public string MoTa { get; set; }
        public int MaNcc { get; set; }

        public virtual Category MaDanhMucNavigation { get; set; }
        public virtual Supplier MaNccNavigation { get; set; }
        public virtual ICollection<Image> Hinhanh { get; set; }
    }
}
