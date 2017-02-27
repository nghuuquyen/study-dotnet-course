using QuanLySinhVien;
using StudentManagingVer2.Forms;
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

namespace StudentManagingVer2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadStudentListToDataGrid();
        }

        private void LoadStudentListToDataGrid()
        {
            SqlConnection conn = DBUtils.OpenConnection();

            if (conn != null)
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM SV", conn);
                DataSet s = new DataSet();
                dataAdapter.Fill(s, "SV");
                dgvSinhVien.DataSource = s.Tables[0];
                conn.Close();
            }
        }

        private void dgvSinhVien_SelectionChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Row was selected.");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddStudentForm form = new AddStudentForm();
            form.Show();
        }
    }
}
