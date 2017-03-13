using StudentManagingStudentManaging3LayersDemo.Models;
using StudentManagingVer2.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManaging3LayersDemo.GUI
{
    public partial class StudentMainForm : Form
    {
        private StudentBLL studentBLL = new StudentBLL();

        public StudentMainForm()
        {
            InitializeComponent();
            LoadStudentList();
        }

        public void LoadStudentList()
        {
            dgvSinhVien.DataSource = studentBLL.getStudents();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddStudentForm form = new AddStudentForm();
            form.addStudent = new AddStudentForm.AddStudent(LoadStudentList);
            form.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection item = dgvSinhVien.SelectedRows;
            int index = dgvSinhVien.SelectedCells[0].RowIndex;
            DataGridViewRow row = dgvSinhVien.Rows[index];

            Student s = new Student();
            s.MSSV = row.Cells[0].Value.ToString(); ;
            s.Name = row.Cells[1].Value.ToString(); ;
            s.DiaChi = row.Cells[3].Value.ToString(); ;
            s.NienKhoa = row.Cells[5].Value.ToString(); ;
            
            // Form settings.
            EditStudentForm form = new EditStudentForm();
            form.updateData = new EditStudentForm.UpdateData(LoadStudentList);

            // Set student selected.
            form.setStudentData(s);
            form.Show();
        }
    }
}
