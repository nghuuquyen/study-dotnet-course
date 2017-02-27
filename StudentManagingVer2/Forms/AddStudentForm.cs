using QuanLySinhVien;
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
        public AddStudentForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SqlConnection conn = DBUtils.OpenConnection();

            if (conn != null)
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM SV", conn);
                SqlCommandBuilder buider = new SqlCommandBuilder(dataAdapter);
                DataSet s = new DataSet();
                dataAdapter.Fill(s, "SV");
                DataTable table = s.Tables[0];

                DataRow newRow = table.NewRow();
                newRow["Name"] = txtTen.Text;
                newRow["DiaChi"] = txtDiaChi.Text;
                table.Rows.Add(newRow);

                buider.DataAdapter.Update(table);
                conn.Close();

                // If completed close form.
                this.Close();
            }
        }
    }
}
