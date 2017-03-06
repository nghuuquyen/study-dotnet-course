using QuanLySinhVien;
using StudentManagingVer2.Models;
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

namespace StudentManagingVer2.Forms
{
    public partial class AddStudentForm : Form
    {
        private DBHelper DBHelper = new DBHelper();
        public delegate void AddStudent();
        public AddStudent addStudent;

        public AddStudentForm()
        {
            InitializeComponent();
            GetListClass();
        }

        public void GetListClass()
        {
            SqlConnection conn = DBUtils.OpenConnection();
            if (conn != null)
            {
                SqlCommand cmd = new SqlCommand("", conn);
                cmd.CommandText = "SELECT * FROM Lop";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cbLop.Items.Add(reader["ID_Lop"]);
                }
                conn.Close();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string sqlCmd = "INSERT INTO SV(MSSV , Name , DiaChi, Nien_Khoa, ID_Lop , Date)"
                          + " VALUES(" 
                          + "'" + txtMSSV.Text + "',"
                          + "'" + txtTen.Text + "',"
                          + "'" + DateTime.Now.ToShortDateString() + "',"
                          + "'" + txtDiaChi.Text + "',"
                          + "'" + "" + "',"
                          + "'" + txtNienKhoa.Text + "',"
                          + "'" + cbLop.SelectedText + "'"
                          + ")";

            DBHelper.DBExcuteNonQuery(sqlCmd);

            if (addStudent != null)
                addStudent.Invoke();

            // If completed close form.
            this.Close();
        }

        private void AddStudentForm_Load(object sender, EventArgs e)
        {

        }
    }
}
