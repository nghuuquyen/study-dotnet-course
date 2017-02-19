using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManaging.Models
{
    class SinhVienCaoDang : SinhVien
    {
        public SinhVienCaoDang() {}

        public SinhVienCaoDang(string diaChi, string dienThoai, string hoTen,
                               int maSo, DateTime ngaySinh, string nienKhoa)
        : base(diaChi, dienThoai, hoTen, maSo, ngaySinh, nienKhoa)
        {

        }

        public override string LoaiHinh()
        {
            return "Cao đẳng";
        }
    }
}
