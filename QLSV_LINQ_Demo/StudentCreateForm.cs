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
    public partial class StudentCreateForm : Form
    {
        SVDataClassesDataContext db = new SVDataClassesDataContext();

        public StudentCreateForm()
        {
            InitializeComponent();
            initLopComboBox();
        }

        private void initLopComboBox()
        {
            var lops = from lop in db.Lops select new { lop.Ten_Lop, lop.ID_Lop , SF = lop.ID_Lop + "-" + lop.Ten_Lop };

            cbxLop.DataSource = lops;
            cbxLop.DisplayMember = "SF";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                SV s = new SV
                {
                    MSSV = txtMSSV.Text,
                    Name = txtHoTen.Text,
                    ID_Lop = int.Parse(cbxLop.SelectedValue.ToString())
                };

                db.SVs.InsertOnSubmit(s);
            }finally
            {
                MessageBox.Show("Saving Data.");
                db.SubmitChanges();
            }

            this.Close();
        }
    }
}
