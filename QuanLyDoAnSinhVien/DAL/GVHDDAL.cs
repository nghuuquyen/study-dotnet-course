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
    class GVHDDAL
    {
        DBHelper DBHelper = new DBHelper();
        public GVHD[] getAllGVHD()
        {
            string sqlCmd = "SELECT * FROM GVHD";
            DataTable d = DBHelper.DBExcuteQuery(sqlCmd);
            int count = d.Rows.Count;

            GVHD[] results = new GVHD[count];
            for (int i = 0; i < count; i++)
            {
                results[i] = GetGVHDFromDataRow(d.Rows[i]);
            }

            return results;
        }

        private GVHD GetGVHDFromDataRow(DataRow row)
        {
            GVHD s = new GVHD();
            s.Ma_Huong_NC = row["Ma_Huong_NC"].ToString();
            s.Ten = row["Ten"].ToString();
            s.ID_GVHD = row["ID_GVHD"].ToString();
            return s;
        }
    }
}
