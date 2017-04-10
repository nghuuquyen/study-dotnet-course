using QLSV_LINQ_3Layer_Demo.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV_LINQ_3Layer_Demo
{
    
    public partial class MainForm : Form
    {
        StudentBLL studentBLL = new StudentBLL();
        public MainForm()
        {
            // Description

            // When we  used LINQ in 3-Layer. LINQ can replace for DTO 
            // DataHelper because it perform Access and Query method.
            // Therefore we only need define BLL( Business Logic Layer) 
            // and DAL ( Data Access Layer).

            // In DAL Object we define method for query to database via 
            // LINQ.

            // And in BLL we call DAL methods for prepared and binding
            // data to view (GUIs)

            InitializeComponent();
            PrepareDataForGridView();
        }

        private void PrepareDataForGridView()
        {
            dataGridView1.DataSource = studentBLL.getAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
