using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitClassListBox();
            //UpdateViewList("14TCLC2");
            //BindingStudentToListBox();
            //BindingStudentToListBoxByDataAdapter();
            //TestUpdateDataByDataAdapter();
            //TestDeleteRowByDataTable();
        }


        private void InitClassListBox()
        {
            SqlConnection conn = DBUtils.OpenConnection();
            if (conn != null)
            {
                SqlCommand cmd = new SqlCommand("", conn);
                cmd.CommandText = "SELECT * FROM Lop";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cboClass.Items.Add(reader["Ten_Lop"]);
                }
                conn.Close();
            }

        }


        private void UpdateViewList(string className)
        {
            lvwStudent.Items.Clear();
            int i = 0;

            SqlConnection conn = DBUtils.OpenConnection();
            if (conn != null)
            {
                SqlCommand cmd = new SqlCommand("", conn);
                cmd.CommandText = "SELECT * FROM SV WHERE Lop.Name = " + className;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["MSSV"].ToString(), i++);
                    item.SubItems.Add(reader["Name"].ToString());
                    item.SubItems.Add(reader["DiaChi"].ToString());
                    lvwStudent.Items.Add(item);
                }
                conn.Close();
            }

          
               
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = DBUtils.OpenConnection();
            if (conn != null)
            {
                SqlCommand cmd = new SqlCommand("", conn);
                cmd.CommandText = "SELECT COUNT(*) FROM SV ";

                int StudentCount = (int)cmd.ExecuteScalar();

                MessageBox.Show("Total Students Is" + StudentCount);
                conn.Close();
            }

        }

        private void BindingStudentToListBox ()
        {
            SqlConnection conn = DBUtils.OpenConnection();
            if (conn != null)
            {
                SqlCommand cmd = new SqlCommand("", conn);
                SqlDataReader reader;
                cmd.CommandText = "SELECT * FROM SV ";

                reader = cmd.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["Name"].ToString(), i++);
                    item.SubItems.Add(reader["DiaChi"].ToString());
                    lvwStudent.Items.Add(item);
                }
                conn.Close();
            }
        }

        private void BindingStudentToListBoxByDataAdapter()
        {
            SqlConnection conn = DBUtils.OpenConnection();
            
            if (conn != null)
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM SV", conn);
                //DataTable ds = new DataTable();
                DataSet s = new DataSet();
                dataAdapter.Fill(s,"SV");
                // DataSource chỉ nhận đối tượng DataTable.
                // Vì DataSet có thể chưa nhiều Table ở trong nên ta làm như dưới.
                dataGridView.DataSource = s.Tables[0];
                conn.Close();
            }
        }

        /**
         *  Thử nghiệm cập nhật dữ liệu bảng Sinh viên thông qua Data Adapter. 
         *  Chú ý phải thực hiện gắn DataAdapter với  SqlCommandBuilder.
         */
        private void TestUpdateDataByDataAdapter()
        {
            SqlConnection conn = DBUtils.OpenConnection();

            if (conn != null)
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM SV", conn);
                // Phải gắn Adapter với SQL Buider mới thao tác cập nhật được.
                SqlCommandBuilder buider = new SqlCommandBuilder(dataAdapter);

                DataSet s = new DataSet();
                // Lấy bảng SV trong DataAdapter bỏ vào DataSet.
                // Chú ý rằng ta có thể bỏ nhiều table vào DataSet và lấy ra 
                // theo thứ tự 
                dataAdapter.Fill(s, "SV");
                
                foreach (DataRow dr in s.Tables[0].Rows)
                {
                    dr["Name"] = "Nguyen Van F";
                    dr["Date"] = DateTime.Now;
                }
                
                buider.DataAdapter.Update(s.Tables[0]);
                //dataAdapter.Update(s.Tables[0]);
                conn.Close();

                MessageBox.Show("Re binding data after updated...");
                BindingStudentToListBoxByDataAdapter();
            }
        }

        private void TestDeleteRowByDataTable()
        {
            SqlConnection conn = DBUtils.OpenConnection();
            string selectedStudentID = "";

            if (conn != null)
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM SV", conn);
                // Phải gắn Adapter với SQL Buider mới thao tác cập nhật được.
                SqlCommandBuilder buider = new SqlCommandBuilder(dataAdapter);

                DataSet s = new DataSet();
                // Lấy bảng SV trong DataAdapter bỏ vào DataSet.
                // Chú ý rằng ta có thể bỏ nhiều table vào DataSet và lấy ra 
                // theo thứ tự 
                dataAdapter.Fill(s, "SV");
                
                DataTable table = s.Tables[0];
                DataRow[] rows = table.Select("MSSV = " + "'" + selectedStudentID + "'");

                if (rows.Length == 0)
                    MessageBox.Show("Not Found Any Row");

                foreach (DataRow dr in rows)
                {
                    dr.Delete();
                }

                buider.DataAdapter.Update(table);
                conn.Close();

                MessageBox.Show("Re binding data after delete...");
                BindingStudentToListBoxByDataAdapter();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = DBUtils.OpenConnection();
            if (conn != null)
            {
                SqlCommand cmd = new SqlCommand("", conn);
                cmd.CommandText = "INSERT INTO SV VALUES ('123123123','QWEQWE','12/12/1996','Da Nang Viet Nam','2015','11111','2')";

                int row = (int)cmd.ExecuteNonQuery();

                MessageBox.Show("Total Success Is" + row);
                conn.Close();
            }
        }
    }
}
