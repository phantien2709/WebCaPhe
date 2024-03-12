using System; 
using System.Collections.Generic;

namespace doan.Models
{
    public partial class PurchaseOrder
    {
        public int MaDdh { get; set; }
        public int MaKh { get; set; }
        public int? MaVoucher { get; set; }
        public decimal? TongDonHang { get; set; }
        public decimal? SoTienGiam { get; set; }
        public decimal? ThanhTien { get; set; }
        public int? MaNv { get; set; }
        public DateTime? NgayDatHang { get; set; }
        public int? MaNvc { get; set; }
        public virtual Customer MaKhNavigation { get; set; }
        public virtual Staff MaNvNavigation { get; set; }
        public virtual Carrier MaNvcNavigation { get; set; }
        public virtual Voucher MaVoucherNavigation { get; set; }
    }
}
