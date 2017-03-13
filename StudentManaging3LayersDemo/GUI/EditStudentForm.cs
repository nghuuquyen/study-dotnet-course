using StudentManaging3LayersDemo;
using StudentManagingStudentManaging3LayersDemo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagingVer2.Forms
{
    public partial class EditStudentForm : Form
    {
        private StudentBLL studentBLL = new StudentBLL();

        public delegate void UpdateData();
        public UpdateData updateData;

        public void setStudentData(Student student)
        {
            txtTen.Text = student.Name;
            txtDiaChi.Text = student.DiaChi;
            txtMSSV.Text = student.MSSV;
            txtNienKhoa.Text = student.NienKhoa;
        }
        
        public EditStudentForm()
        {
            InitializeComponent();

            // Never allow edit Student CODE.
            txtMSSV.Enabled = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Student s = new Student();

            s.Name = txtTen.Text;
            s.NienKhoa = txtNienKhoa.Text;
            s.MSSV = txtMSSV.Text;
            s.DiaChi = txtDiaChi.Text;

            studentBLL.updateStudent(s);

            // Call method update student list data of main form.
            if (updateData != null)
                updateData.Invoke();

            this.Close();
        }
    }
}
