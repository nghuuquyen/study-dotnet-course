using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDoAnSinhVien.DTO
{
    public class HuongNghienCuu
    {
        public string Ma_Huong_NC { get; set; }
        public string Ten { get; set; }
        public string ID_GVHD { get; set; }

        public override string ToString()
        {
            return Ten;
        }
    }
}
