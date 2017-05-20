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
