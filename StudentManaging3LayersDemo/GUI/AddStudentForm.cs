using StudentManaging3LayersDemo;
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
        private LopBLL lopBll = new LopBLL();
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
            foreach(var item in lopBll.getListLop())
            {
                cbLop.Items.Add(item.IDLop);
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
