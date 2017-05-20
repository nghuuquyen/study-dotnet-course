using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_QuanLySinhVien.DAL
{
    class KhoaDAL
    {
        public List<Khoa> getAll()
        {
            using ( var db = new StudentDB())
            {
                return db.Khoas.Select(k => k).ToList();
            }
        }
    }
}
