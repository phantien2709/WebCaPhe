using System; 
using System.Collections.Generic;

namespace doan.Models
{
    public partial class Image
    {
        public int MaHinhAnh { get; set; }
        public string LinkHinhAnh { get; set; }
        public int? MaSp { get; set; }

        public virtual Product MaSpNavigation { get; set; }
    }
}
