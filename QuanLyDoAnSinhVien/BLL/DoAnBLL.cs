using QuanLyDoAnSinhVien.DAL;
using QuanLyDoAnSinhVien.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDoAnSinhVien.BLL
{
    class DoAnBLL
    {
        private DoAnDAL doAnDAL = new DoAnDAL();

        public DoAn[] getListDoAn()
        {
            return doAnDAL.getAllDoAn();
        }

        public void remove(DoAn da)
        {
            doAnDAL.remove(da);
        }

        public void save(DoAn da)
        {
            doAnDAL.save(da);
        }

        public void update(DoAn da)
        {
            doAnDAL.update(da);
        }
    }
}
