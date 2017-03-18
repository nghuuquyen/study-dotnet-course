using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManaging3LayersDemo
{
    class DBHelper
    {
        private SqlConnection conn;

        public DBHelper()
        {
            string s = "Data Source=ACER;Initial Catalog=QL_Do_An;Integrated Security=True";
            conn = new SqlConnection(s);
        }

        public void DBExcuteNonQuery(string s)
        {
            SqlCommand cmd = new SqlCommand(s, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public DataTable DBExcuteQuery(string s)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(s, conn);
            conn.Open();
            DataTable t = new DataTable();
            adapter.Fill(t);
            conn.Close();
            return t;
        }

        public SqlDataReader DBExcuteReader(string s)
        {
            SqlCommand cmd = new SqlCommand(s, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public SqlCommand GetSqlCommand(string s)
        {
            return new SqlCommand(s, conn);
        }

        public void OpenConnection()
        {
            conn.Open();
        }

        public void CloseConnection ()
        {
            conn.Close();
        }
    }
}
