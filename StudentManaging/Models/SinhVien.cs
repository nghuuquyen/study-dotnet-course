using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManaging.Models
{
    class SinhVien
    {
        private string diaChi;
        private string dienThoai;
        private string hoTen;
        private int maSo;
        private DateTime ngaySinh;
        private string nienKhoa;
        public SinhVien()
        {
        }

        public SinhVien(string diaChi, string dienThoai, string hoTen, int maSo, DateTime ngaySinh, string nienKhoa)
        {
            this.diaChi = diaChi;
            this.dienThoai = dienThoai;
            this.hoTen = hoTen;
            this.maSo = maSo;
            this.ngaySinh = ngaySinh;
            this.nienKhoa = nienKhoa;
        }
        public string DIACHI
        {
            get { return this.diaChi; }
            set { this.diaChi = value; }
        }

        public string DIENTHOAI
        {
            get { return this.dienThoai; }
            set { this.dienThoai = value; }
        }

        public string HOTEN
        {
            get { return this.hoTen; }
            set { this.hoTen = value; }
        }

        public int MSSV
        {
            get { return this.maSo; }
            set { this.maSo = value; }
        }
        public DateTime NGAYSINH
        {
            get { return this.ngaySinh; }
            set { this.ngaySinh = value; }
        }

        public string NIENKHOA
        {
            get { return this.nienKhoa; }
            set { this.nienKhoa = value; }
        }
        public virtual string LoaiHinh() { return ""; }
    }
}
