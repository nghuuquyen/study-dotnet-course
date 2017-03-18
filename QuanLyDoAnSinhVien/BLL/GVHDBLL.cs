using QuanLyDoAnSinhVien.DAL;
using QuanLyDoAnSinhVien.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDoAnSinhVien.BLL
{
    class GVHDBLL
    {
        GVHDDAL dal = new GVHDDAL();
        public GVHD[] getAllGVHD()
        {
            return dal.getAllGVHD();
        }
    }
}
