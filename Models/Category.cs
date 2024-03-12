using System; 
using System.Collections.Generic;

namespace doan.Models
{
    public partial class Category
    {
        public Category()
        {
            Sanpham = new HashSet<Product>();
        }

        public int MaDanhMuc { get; set; }
        public string TenDanhMuc { get; set; }
        public string MoTa { get; set; }

        public virtual ICollection<Product> Sanpham { get; set; }
    }
}
