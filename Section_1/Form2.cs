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
    public partial class Form2 : Form
    {
        private TextBox textBox;

        public delegate void ShowText(String s);
        public ShowText text;

        public Form2()
        {   
            InitializeComponent();
        }
        
        public void setTextBox1(TextBox textBox1)
        {
            this.textBox = textBox1;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //this.textBox.Text = this.textBox1.Text;
            if(text != null)
            {
                text.Invoke(this.textBox1.Text);
            }
        }
    }
}
