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
    public partial class RemoveStudentForm : Form
    {
        private StudentBLL studentBLL = new StudentBLL();
        private Student studentSelected = null;
        public delegate void RemoveStudent(Student s);
        public RemoveStudent removeStudent;

        public RemoveStudentForm()
        {
            InitializeComponent();
        }
        public void setStudentData(Student s)
        {
            studentSelected = s;

            txtName.Enabled = false;
            txtMSSV.Enabled = false;

            txtName.Text = s.Name;
            txtMSSV.Text = s.MSSV;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            if (studentSelected == null)
                return;

            // Call method for update main form.
            if (removeStudent != null)
                removeStudent.Invoke(studentSelected);

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
