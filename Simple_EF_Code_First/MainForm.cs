using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_EF_Code_First
{
    public partial class MainForm : Form
    {
        StudentDBModel db = new StudentDBModel();

        public MainForm()
        {
            var khoa = new Khoa()
            {
                MSKhoa = "Khoa01",
                Name = "Khoa Cong Nghe Thong Tin"
            };
           
            db.Khoas.Add(khoa);
            db.SaveChanges();
            InitializeComponent();
        }
    }
}
