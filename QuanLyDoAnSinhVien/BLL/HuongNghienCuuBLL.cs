using QuanLyDoAnSinhVien.DAL;
using QuanLyDoAnSinhVien.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDoAnSinhVien.BLL
{
    class HuongNghienCuuBLL
    {
        HuongNghienCuuDAL dal = new HuongNghienCuuDAL();
        public HuongNghienCuu[] getAllHNC()
        {
            return dal.getAllHNC();
        }
    }
}
