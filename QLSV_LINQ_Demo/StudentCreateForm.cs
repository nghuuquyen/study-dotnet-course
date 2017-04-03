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
            // Chú ý là ở đây tạo ra một thuộc tính mới có tên là "SF"
            var lops = from lop in db.Lops select new { lop.Ten_Lop, lop.ID_Lop , SF = lop.ID_Lop + "-" + lop.Ten_Lop };

            cbxLop.DataSource = lops;
            // Sau đó gán thuộc tính hiển thị là "SF"
            cbxLop.DisplayMember = "SF";

            // Và thuộc tính sẽ lấy giá trị chính là "ID_Lop"
            cbxLop.ValueMember = "ID_Lop";
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
                // Lưu tạm nó vào SVs hiện tại , chưa được lưu vào DB
                db.SVs.InsertOnSubmit(s);
            }
            finally
            {
                MessageBox.Show("Saving Data.");

                // Tới đây mới thực sự lưu vào DB, như vậy có thể chèn nhiều Record cùng 
                // lúc.
                db.SubmitChanges();
            }

            this.Close();
        }
    }
}
