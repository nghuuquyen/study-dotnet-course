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

        public List<SV> findByName(string name)
        {
            SVDAL svDAL = new SVDAL();
            return svDAL.findByName(name);
        }

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
            model.MaKhoa = sv.MaKhoa;
            return model;
        }

        public StudentViewModel coverSVToStudentViewModel(SV sv)
        {
            SVDAL svDAL = new SVDAL();
            StudentViewModel model = new StudentViewModel();

            if (sv == null) return null;

            model.TenSV = sv.TenSV;
            model.GioiTinh = sv.GioiTinh;
            model.HoKhau = sv.HoKhau;
            model.MSSV = sv.MSSV;
            model.NgaySinh = sv.NgaySinh;
            model.QueQuan = sv.QueQuan;
            model.DiemTB = sv.DiemTB;
            model.MaKhoa = sv.MaKhoa;
            return model;
        }

        public SV coverStudentViewModelToSV(StudentViewModel model)
        {
            SV sv = new SV();
            KhoaBLL khoaBLL = new KhoaBLL();

            sv.TenSV = model.TenSV;
            sv.GioiTinh = model.GioiTinh;
            sv.HoKhau = model.HoKhau;
            sv.MSSV = model.MSSV;
            sv.NgaySinh = model.NgaySinh;
            sv.QueQuan = model.QueQuan;
            sv.MaKhoa = model.MaKhoa;
            sv.Khoa = khoaBLL.findById(model.MaKhoa.GetValueOrDefault());

            return sv;
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

        public static bool CompareMSSV(object o1, object o2)
        {
            if (((SV)o1).MSSV > ((SV)o2).MSSV)
            {
                return true;
            }
            return false;
        }

        public static bool CompareStudentName(object o1, object o2)
        {
            if (String.Compare(((SV)o1).TenSV, ((SV)o2).TenSV) > 0)
            {
                return true;
            }
            return false;
        }

        public static bool CompareDiemTB(object o1, object o2)
        {
            if (((SV)o1).DiemTB > ((SV)o2).DiemTB)
            {
                return true;
            }
            return false;
        }

        public static bool CompareKhoaName(object o1, object o2)
        {
            if (String.Compare(((SV)o1).Khoa.Ten, ((SV)o2).Khoa.Ten) > 0)
            {
                return true;
            }
            return false;
        }
    }
}
