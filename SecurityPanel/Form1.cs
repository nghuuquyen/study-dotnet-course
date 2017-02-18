using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecurityPanel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OnClickedNumberButton(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null)
                return;

            codeTxt.Text += btn.Text;
        }

        private void OnSubmitCode(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null)
                return;

            String code = codeTxt.Text;
            if (code == "") MessageBox.Show("Please Enter Code");
            else
            {
                int codeNumber;
                if (Int32.TryParse(code, out codeNumber))
                {
                    listBox.Items.Add(GetLogMessage("Restricted Access !"));
                    listBox.Items.Add(GetLogMessage(getAccessGrantType(codeNumber)));
                }
                else
                    Console.WriteLine("String could not be parsed.");
            }
        }

        private String GetLogMessage(String message)
        {
            return DateTime.Now.ToString("G") + "  " + message;
        }

        private String getAccessGrantType(int code)
        {
            // 1645 or 1689 Technicians
            // 8345 Custodians
            // 9998, 1006 - 1008 Scientist

            if (code >= 1645 && code <= 1689)
                return "Technicians";
            else if (code == 9998 || (code >= 1006 && code <= 1008))
                return "Scientist";
            else if (code == 8345)
                return "Custodians";

            return "Access denied";
        }

        private void OnResetForm(object sender, EventArgs e)
        {
            codeTxt.Text = "";
        }
    }
}
