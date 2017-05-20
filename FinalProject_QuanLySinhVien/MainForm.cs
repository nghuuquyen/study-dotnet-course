using FinalProject_QuanLySinhVien.BLL;
using FinalProject_QuanLySinhVien.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject_QuanLySinhVien
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            dvgSinhVien.AutoGenerateColumns = false;
            LoadALLStudentToDataGrid();
        }

        public void LoadALLStudentToDataGrid()
        {
            using (var db = new StudentDB())
            {
                SVBLL svBLL = new SVBLL();
                dvgSinhVien.DataSource = svBLL.getDataGridViewModel();
            }
        }

        public SV getSelectedStudentFromGrid()
        {

            return null;
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
