using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framwork_Code_First.Models
{
    public class SinhVienDiaChi
    {
        public int id { get; set; }
        public string diachi1 { get; set; }
        public string diachi2 { get; set; }
        public string thanhPho { get; set; }

        public virtual SinhVien SinhVien { get; set; }
    }
}
