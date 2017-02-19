using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManaging.Models
{
    class SinhVienDaiHoc:SinhVien
    {
        private string chuyenNganh;

        public SinhVienDaiHoc() {

        }

        public SinhVienDaiHoc(string diaChi, string dienThoai, string hoTen, string maSo, 
                              DateTime ngaySinh, string nienKhoa, string chuyenNganh)
        :base(diaChi, dienThoai, hoTen, maSo, ngaySinh, nienKhoa)
        {
            this.chuyenNganh = chuyenNganh;
        }

        public string ChuyenNganh
        {
            get { return this.chuyenNganh; }
            set { this.chuyenNganh = value; }
        }

        public override string LoaiHinh()
        {
            return "Đại học";
        }
    }
}
