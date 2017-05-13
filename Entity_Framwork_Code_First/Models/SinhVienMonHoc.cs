using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framwork_Code_First.Models
{
    public class SinhVienMonHoc
    {
        public int id { get; set; }
        public int sinhVienId { get; set; }
        public int monHocId { get; set; }
        public virtual SinhVien SinhVien { get; set; }
        public virtual MonHoc MonHoc { get; set; } 
    }
}
