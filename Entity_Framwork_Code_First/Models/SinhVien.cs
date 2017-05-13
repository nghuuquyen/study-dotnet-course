using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framwork_Code_First.Models
{
    public class SinhVien
    {

        public SinhVien()
        {
            // Chỉ quan hệ một nhiều thông qua khóa chính mới cần khởi tạo.
            this.MonHocs = new HashSet<SinhVienMonHoc>();
        }
        public int id { get; set; }
        public string hoten { get; set; }
        public string sodienthoai { get; set; }
        public string email { get; set; }
        public int lopId { get; set; }

        public virtual Lop Lop { get; set; }
        public virtual SinhVienDiaChi DiaChi { get; set; }
        public virtual ICollection<SinhVienMonHoc> MonHocs { get; set; }
    }
}
