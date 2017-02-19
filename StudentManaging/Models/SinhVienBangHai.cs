using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManaging.Models
{
    class SinhVienBangHai:SinhVien
    {
        private string bang1;
        private string donVi;

        public SinhVienBangHai() { }

        public SinhVienBangHai(string bang1, string donVi, string diaChi, string dienThoai, 
                               string hoTen, string maSo, DateTime ngaySinh, string nienKhoa)
        :base(diaChi, dienThoai, hoTen, maSo, ngaySinh, nienKhoa)
        {
            this.bang1 = bang1;
            this.donVi = donVi;
        }

        public string Bang1
        {
            get { return this.bang1; }
            set { this.bang1 = value; }
        }

        public string DonVi
        {
            get { return this.donVi; }
            set { this.donVi = value; }
        }

        public override string LoaiHinh()
        {
            return "Bằng hai";
        }
    }
}
