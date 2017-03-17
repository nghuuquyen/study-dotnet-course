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
    public partial class FilterByClassForm : Form
    {
        private LopBLL lopBLL = new LopBLL();
        private StudentBLL studentBLL = new StudentBLL();

        public FilterByClassForm()
        {
            InitializeComponent();
            initComboBox();
            initDataGrid();
        }

        private void initComboBox()
        {
            cbxLop.Items.Add("All Class");

            foreach (var lop in lopBLL.getListLop())
            {
                cbxLop.Items.Add(lop);
            }
        }

        private void initDataGrid()
        {
            dgvSinhVien.DataSource = studentBLL.getStudents();
        }

        private void UpdateFilter()
        {
            // index 0 is 'All Class'
            if (cbxLop.SelectedIndex != 0)
                dgvSinhVien.DataSource = studentBLL.getListStudentByClass((Lop)cbxLop.SelectedItem);
            else
                dgvSinhVien.DataSource = studentBLL.getStudents();
        }

        private void cbxLop_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UpdateFilter();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            var from = dtpFrom.Value.Date;
            var to = dtpTo.Value.Date;

            if (from == null && to == null)
                return;

            Student[] students = studentBLL.getStudents();
            MessageBox.Show("From: " + from + " To: " + to);
            MessageBox.Show(from.ToString("dd/MM/yy"));
        }
    }
}
