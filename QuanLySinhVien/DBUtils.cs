using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QuanLySinhVien
{
    class DBUtils
    {
        public static SqlConnection OpenConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=ACER;Initial Catalog=QLSV;Integrated Security=True";

            try
            {
                conn.Open();
            }
            catch(Exception ex)
            {
                return null;
            }
            return conn;
        }
    }
}
