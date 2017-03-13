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
        private LopBLL lopBLL = new LopBLL();

        public delegate void SearchStudentByName(string name);
        public SearchStudentByName searchStudentByName;

        public StudentMainForm()
        {
            InitializeComponent();
            LoadStudentList();
        }

        public void UpdateLopName()
        {

        }

        public void LoadStudentList()
        {
            Student[] students = studentBLL.getStudents();
            Lop[] lops = lopBLL.getListLop();
            dgvSinhVien.DataSource = students;
  
            for (int i = 0; i < students.Length; i++)
                for (int j = 0; j < lops.Length; j++)
                {
                    if (students[i].ID_Lop == lops[j].IDLop)
                    {
                        // Index 7 is column Ten_Lop.
                        //dgvSinhVien.Rows[i].Cells[7].Value = lops[j].TenLop;
                    }
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddStudentForm form = new AddStudentForm();
            form.addStudent = new AddStudentForm.AddStudent(LoadStudentList);
            form.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Form settings.
            EditStudentForm form = new EditStudentForm();
            form.updateData = new EditStudentForm.UpdateData(LoadStudentList);

            // Set student selected.
            form.setStudentData(getStudentSelectedFromGridView());
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RemoveStudentForm form = new RemoveStudentForm();
            form.removeStudent = new RemoveStudentForm.RemoveStudent(removeSelectedStudent);
            form.setStudentData(getStudentSelectedFromGridView());
            form.Show();
        }

        private Student getStudentSelectedFromGridView()
        {
            DataGridViewSelectedRowCollection item = dgvSinhVien.SelectedRows;
            int index = dgvSinhVien.SelectedCells[0].RowIndex;
            DataGridViewRow row = dgvSinhVien.Rows[index];

            Student s = new Student();
            s.MSSV = row.Cells[0].Value.ToString();
            s.Name = row.Cells[1].Value.ToString();
            s.DiaChi = row.Cells[3].Value.ToString();
            s.NienKhoa = row.Cells[5].Value.ToString();

            return s;
        }

        private void removeSelectedStudent(Student s)
        {
            studentBLL.removeStudent(s);
            LoadStudentList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            StudentSearchForm form = new StudentSearchForm();
            form.prepareSearchByName(txtSearch.Text);
            form.Show();
        }
    }
}
