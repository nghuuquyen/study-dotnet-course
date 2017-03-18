using QuanLyDoAnSinhVien.DTO;
using StudentManaging3LayersDemo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDoAnSinhVien.DAL
{
    class HuongNghienCuuDAL
    {
        DBHelper DBHelper = new DBHelper();
        public HuongNghienCuu[] getAllHNC()
        {
            string sqlCmd = "SELECT * FROM HuongNghienCuu";
            DataTable d = DBHelper.DBExcuteQuery(sqlCmd);
            int count = d.Rows.Count;

            HuongNghienCuu[] results = new HuongNghienCuu[count];
            for (int i = 0; i < count; i++)
            {
                results[i] = GetHNCFromDataRow(d.Rows[i]);
            }

            return results;
        }

        private HuongNghienCuu GetHNCFromDataRow(DataRow row)
        {
            HuongNghienCuu s = new HuongNghienCuu();
            s.Ma_Huong_NC = row["Ma_Huong_NC"].ToString();
            s.Ten = row["Ten"].ToString();
            s.ID_GVHD = row["ID_GVHD"].ToString();
            return s;
        }
    }
}
