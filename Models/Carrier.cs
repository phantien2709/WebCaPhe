using System; 
using System.Collections.Generic;

namespace doan.Models
{
    public partial class Carrier
    {
        public Carrier()
        {
            Dondathang = new HashSet<PurchaseOrder>();
        }

        public int MaNvc { get; set; }
        public string TenNvc { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }

        public virtual ICollection<PurchaseOrder> Dondathang { get; set; }
    }
}
