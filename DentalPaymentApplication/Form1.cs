using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentalPaymentApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public bool isFormValid()
        {
            if(txtName.Text == "")
            {
                MessageBox.Show("Xin vui lòng nhập tên khách hàng.");
            }
             
            return true;
        }

        public void getPay()
        {
            long total = 0;

            if (chkClean.Checked)
                total += 100000;
                
            if (chkWhitening.Checked)
                total += 1200000;

            if (chkXRay.Checked)
                total += 200000;

            total += (long) this.numFilling.Value * 80000;

            this.txtTotal.Text = total.ToString();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            if(isFormValid())
            {
                getPay();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
