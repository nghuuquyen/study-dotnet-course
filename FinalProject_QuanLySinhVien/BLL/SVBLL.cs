using FinalProject_QuanLySinhVien.DAL;
using FinalProject_QuanLySinhVien.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_QuanLySinhVien.BLL
{
    public class SVBLL
    {
        public void create(SV sv)
        {
            SVDAL svDAL = new SVDAL();
            svDAL.create(sv);
        }

        public StudentViewModel getStudentViewModelByID(int id)
        {
            SVDAL svDAL = new SVDAL();
            StudentViewModel model = new StudentViewModel();
            SV sv = svDAL.findByID(id);

            if (sv == null) return null;

            model.TenSV = sv.TenSV;
            model.GioiTinh = sv.GioiTinh;
            model.HoKhau = sv.HoKhau;
            model.MSSV = sv.MSSV;
            model.NgaySinh = sv.NgaySinh;
            model.QueQuan = sv.QueQuan;
            model.DiemTB = sv.DiemTB;
            return model;
        }

        public SV coverStudentViewModelToSV(StudentViewModel model)
        {
            SV sv = new SV();

            sv.TenSV = model.TenSV;
            sv.GioiTinh = model.GioiTinh;
            sv.HoKhau = model.HoKhau;
            sv.MSSV = model.MSSV;
            sv.NgaySinh = model.NgaySinh;
            sv.QueQuan = model.QueQuan;
            sv.MaKhoa = model.MaKhoa;

            return null;
        }
        public void update(SV sv)
        {
            SVDAL svDAL = new SVDAL();
            svDAL.update(sv);
        }

        public void remove(SV sv)
        {
            SVDAL svDAL = new SVDAL();
            svDAL.remove(sv);
        }

        public void findByID(int id)
        {
            SVDAL svDAL = new SVDAL();
            svDAL.findByID(id);
        }

        public List<SV> getAll()
        {
            SVDAL svDAL = new SVDAL();
            return svDAL.getALL();
        }

        public List<StudentViewModel> getDataGridViewModel()
        {
            SVDAL svDAL = new SVDAL();
            return svDAL.getDataGridViewModel();
        }
    }
}
