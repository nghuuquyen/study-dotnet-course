using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Section_1
{
    public partial class Form1 : Form
    {
        
        private String text = "";
        private Form2 form2 = new Form2();

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            form2.textBox1.Text = this.textBox1.Text;
        }

        public void showMessage(String s)
        {
            this.textBox1.Text = s;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //form2.setTextBox1(this.textBox1);

            form2.text = new Form2.ShowText(showMessage);
            form2.Show();
        }
    }
}
