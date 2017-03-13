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
    public partial class StudentSearchForm : Form
    {
        private StudentBLL studentBLL = new StudentBLL();
        public StudentSearchForm()
        {
            InitializeComponent();
        }

        public void prepareSearchByName(string name)
        {
            dgvSinhVien.DataSource = studentBLL.searchByStudentName(name);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
