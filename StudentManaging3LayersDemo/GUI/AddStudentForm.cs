using StudentManaging3LayersDemo;
using StudentManagingStudentManaging3LayersDemo.Models;
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
        private StudentBLL studentBLL = new StudentBLL();
        public delegate void AddStudent();
        public AddStudent addStudent;
        private DBHelper dbHeper = new DBHelper();

        public AddStudentForm()
        {
            InitializeComponent();
            GetListClass();
        }

        public void GetListClass()
        {
            SqlDataReader reader = dbHeper.DBExcuteReader("Select * From lop");
            while(reader.Read())
            {
                cbLop.Items.Add(reader["id_lop"]);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Student s = new Student();
            s.MSSV = txtMSSV.Text;
            s.Name = txtTen.Text;
            s.DiaChi = txtDiaChi.Text;
            s.NienKhoa = txtNienKhoa.Text;
            s.ID_Lop = cbLop.SelectedItem.ToString();
            s.Date = DateTime.Now;

            studentBLL.saveStudent(s);

            if (addStudent != null)
                addStudent.Invoke();

            // If completed close form.
            this.Close();
        }
    }
}
