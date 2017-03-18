using QuanLyDoAnSinhVien.DTO;
using StudentManaging3LayersDemo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDoAnSinhVien.DAL
{
    class DoAnDAL
    {
        DBHelper DBHelper = new DBHelper();
        public DoAn[] getAllDoAn()
        {
            string sqlCmd = "SELECT * FROM DoAN";
            DataTable d = DBHelper.DBExcuteQuery(sqlCmd);
            int count = d.Rows.Count;

            DoAn[] doAns = new DoAn[count];
            for (int i = 0; i < count; i++)
            {
                doAns[i] = GetDoAnFromDataRow(d.Rows[i]);
            }

            return doAns;
        }

        private DoAn GetDoAnFromDataRow(DataRow row)
        {
            DoAn s = new DoAn();
            s.MaDoAn = row["Ma_Do_An"].ToString();
            s.TenDoAn = row["Ten_Do_An"].ToString();
            s.TenSV = row["Ten_SV"].ToString();
            s.NamThucHien = (int) row["Nam_Thuc_Hien"];
            s.TinhTrang = false;
            s.Ma_Huong_NC = row["Ma_Huong_NC"].ToString();
            s.ID_GVHD = row["ID_GVHD"].ToString();
            return s;
        }

        public void update(DoAn da)
        {
            string updateCmdString = "";
            updateCmdString = " UPDATE DoAN"
            + " SET Ma_Do_An = @MDA, Ten_Do_An = @TDA , Ten_SV = @TSV, Nam_Thuc_Hien = @NTH, Tinh_Trang = @TT, Ma_Huong_NC = @MHNC, ID_GVHD = @ID_GVHD";


            DBHelper.OpenConnection();
            SqlCommand cmd = DBHelper.GetSqlCommand(updateCmdString);

            cmd.Parameters.AddWithValue("@MDA", da.MaDoAn);
            cmd.Parameters.AddWithValue("@TDA", da.TenDoAn);
            cmd.Parameters.AddWithValue("@TSV", da.TenSV);
            cmd.Parameters.AddWithValue("@NTH", da.NamThucHien);
            cmd.Parameters.AddWithValue("@TT", da.TinhTrang);
            cmd.Parameters.AddWithValue("@MHNC", da.Ma_Huong_NC);
            cmd.Parameters.AddWithValue("@ID_GVHD", da.ID_GVHD);

            cmd.ExecuteNonQuery();
            DBHelper.CloseConnection();
        }

        public void save(DoAn da)
        {
            string sqlCmd = "INSERT INTO DoAN(Ma_Do_An , Ten_Do_An , Ten_SV, Nam_Thuc_Hien, Tinh_Trang , Ma_Huong_NC , ID_GVHD) "
                          + "VALUES( @MDA,@TDA ,@TSV,@NTH,@TT,@MHNC,@ID_GVHD)";

            DBHelper.OpenConnection();
            SqlCommand cmd = DBHelper.GetSqlCommand(sqlCmd);

            cmd.Parameters.AddWithValue("@MDA", da.MaDoAn);
            cmd.Parameters.AddWithValue("@TDA", da.TenDoAn);
            cmd.Parameters.AddWithValue("@TSV", da.TenSV);
            cmd.Parameters.AddWithValue("@NTH", da.NamThucHien);
            cmd.Parameters.AddWithValue("@TT", da.TinhTrang);
            cmd.Parameters.AddWithValue("@MHNC", da.Ma_Huong_NC);
            cmd.Parameters.AddWithValue("@ID_GVHD", da.ID_GVHD);

            cmd.ExecuteNonQuery();
            DBHelper.CloseConnection();
        }

        public void remove(DoAn da)
        {
            string sqlCmd = "DELETE FROM DoAN WHERE Ma_Do_An = ";
            sqlCmd += da.MaDoAn;

            DBHelper.DBExcuteNonQuery(sqlCmd);
        }

        public DoAn[] findByName(string name)
        {
            string sqlCmd = "SELECT * FROM DoAN WHERE DoAN.Ten_Do_An LIKE " + "'%" + name + "%'";
            DataTable d = DBHelper.DBExcuteQuery(sqlCmd);
            int count = d.Rows.Count;

            DoAn[] doAns = new DoAn[count];
            for (int i = 0; i < count; i++)
            {
                doAns[i] = GetDoAnFromDataRow(d.Rows[i]);
            }

            return doAns;
        }
    }
}
