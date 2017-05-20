using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_QuanLySinhVien.ViewModels
{
    public class StudentViewModel
    {
        public int STT { get; set; }
        public int MSSV { get; set; }

        public string TenSV { get; set; }

        public DateTime? NgaySinh { get; set; }

        public string QueQuan { get; set; }

        public string HoKhau { get; set; }

        public bool? GioiTinh { get; set; }

        public double? DiemTB { get; set; }
        
        public string TenKhoa { get; set; }

        public int? MaKhoa { get; set; }
    }
}
