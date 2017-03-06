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
            foreach(Student s in studentBLL.getStudents()) {
                lbxStudent.Items.Add(s.Name);
            }
        }
    }
}
