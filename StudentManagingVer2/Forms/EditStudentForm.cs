using StudentManagingVer2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagingVer2.Forms
{
    public partial class EditStudentForm : Form
    {
        private DBHelper DBHelper = new DBHelper();
        public delegate void UpdateData();
        public UpdateData updateData;

        public void setStudentData(Student student)
        {
            txtTen.Text = student.Name;
            txtDiaChi.Text = student.DiaChi;
            txtMSSV.Text = student.MSSV;
            txtNienKhoa.Text = student.NienKhoa;
        }
        
        public EditStudentForm()
        {
            InitializeComponent();

            // Never allow edit Student CODE.
            txtMSSV.Enabled = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string updateCmdString = "";
            updateCmdString = " UPDATE SV"
                            + " SET " 
                            + " Name = '" + txtTen.Text + "',"
                            + " DiaChi = '" + txtDiaChi.Text + "',"
                            + " Nien_Khoa = " + txtNienKhoa.Text 
                            + " WHERE SV.MSSV = '" + txtMSSV.Text + "'";
                            
            DBHelper.DBExcuteNonQuery(updateCmdString);

            // Call method update student list data of main form.
            if (updateData != null)
                updateData.Invoke();

            this.Close();
        }
    }
}
