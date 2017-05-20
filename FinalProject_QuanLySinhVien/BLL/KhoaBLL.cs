using FinalProject_QuanLySinhVien.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_QuanLySinhVien.BLL
{
    public class KhoaBLL
    {
        KhoaDAL khoaDAL = new KhoaDAL();

        public List<Khoa> getAll()
        {
            return khoaDAL.getAll();
        }
    }
}
