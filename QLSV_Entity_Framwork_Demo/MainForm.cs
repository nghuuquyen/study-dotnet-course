using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV_Entity_Framwork_Demo
{
    public partial class MainForm : Form
    {
        QLSVEntities db = new QLSVEntities();
        public MainForm()
        {
            InitializeComponent();

            dataGridView1.DataSource = db.SVs.Select(s => s).ToList();
        }
    }
}
