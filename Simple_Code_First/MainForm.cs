using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Code_First
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            MyDBContext db = new MyDBContext();

            //var SV_1 = new SV
            //{
            //    MSSV = 1,
            //    HoTen = "Nguyen Huu Quyen",
            //    ID_Khoa = 1
            //};

            //db.SVs.Add(SV_1);
            //db.SaveChanges();

            MessageBox.Show("Total SVs: " + db.SVs.Select(s => s).ToArray().Length);
        }
    }
}
