using QuanLySinhVien;
using StudentManagingVer2.Forms;
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

namespace StudentManagingVer2
{
    public partial class MainForm : Form
    {
        private DBHelper DBHelper = new DBHelper();
        public MainForm()
        {
            InitializeComponent();
            LoadStudentListToDataGrid();
        }

        private void LoadStudentListToDataGrid()
        {
            dgvSinhVien.DataSource = DBHelper.DBExcuteQuery("SELECT * FROM SV");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddStudentForm form = new AddStudentForm();
            form.addStudent += new AddStudentForm.AddStudent(LoadStudentListToDataGrid);
            form.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection item = dgvSinhVien.SelectedRows;
                int index = dgvSinhVien.SelectedCells[0].RowIndex;
                DataGridViewRow row = dgvSinhVien.Rows[index];

                Student s = new Student();
                s.MSSV = row.Cells[0].Value.ToString(); ;
                s.Name = row.Cells[1].Value.ToString(); ;
                s.DiaChi = row.Cells[3].Value.ToString(); ;
                s.NienKhoa = row.Cells[5].Value.ToString(); ;

                EditStudentForm form = new EditStudentForm();
                form.updateData = new EditStudentForm.UpdateData(LoadStudentListToDataGrid);
                form.setStudentData(s);
                form.Show();
            }
            catch (Exception) { MessageBox.Show("Error"); }
        }
    }
}
