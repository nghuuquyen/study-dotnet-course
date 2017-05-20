using FinalProject_QuanLySinhVien.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_QuanLySinhVien.DAL
{
    public class SVDAL
    {
        public List<SV> getALL()
        {
            var db = new StudentDB();
            return db.SVs.Select(s => s).ToList();
        }

        public List<StudentViewModel> getDataGridViewModel()
        {
            var db = new StudentDB();
            return db.SVs.Select(s => new StudentViewModel
            {
                MSSV = s.MSSV,
                TenSV = s.TenSV,
                NgaySinh = s.NgaySinh,
                GioiTinh = s.GioiTinh,
                DiemTB = s.DiemTB,
                TenKhoa = s.Khoa.Ten
            }).ToList();
        }

        public SV findByID(int id)
        {
            using (var db = new StudentDB())
            {
                return db.SVs.Find(id);
            }
        }


        public void update(SV sv)
        {
            using (var db = new StudentDB())
            {
                db.Entry(db.SVs.Find(sv.MSSV)).CurrentValues.SetValues(sv);
                db.SaveChanges();
            }
        }

        public void create(SV sv)
        {
            using (var db = new StudentDB())
            {
                db.SVs.Add(sv);
                db.SaveChanges();
            }
        }

        public void remove(SV sv)
        {
            using (var db = new StudentDB())
            {
                db.SVs.Remove(sv);
                db.SaveChanges();
            }
        }
    }
}
