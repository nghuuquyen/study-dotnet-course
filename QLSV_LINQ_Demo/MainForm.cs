using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV_LINQ_Demo
{
    public partial class MainForm : Form
    {
        SVDataClassesDataContext db = new SVDataClassesDataContext();
        public MainForm()
        {
            InitializeComponent();
            initDataGridView();
        }

        private void initDataGridView()
        {
            var data = db.SVs.Join(db.Lops, sv => sv.ID_Lop, lop => lop.ID_Lop,
                (sv, lop) =>  new {sv.MSSV, SVName = sv.MSSV, sv.Date, SVAddress = sv.DiaChi, sv.tel, LopName = lop.Ten_Lop });

            dataGridView1.DataSource = data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentCreateForm form = new StudentCreateForm();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            initDataGridView();
        }
    }
}
