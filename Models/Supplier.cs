using System; 
using System.Collections.Generic;

namespace doan.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Sanpham = new HashSet<Product>();
        }

        public int MaNcc { get; set; }
        public string TenNcc { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Product> Sanpham { get; set; }
    }
}
