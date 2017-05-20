using FinalProject_QuanLySinhVien.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject_QuanLySinhVien.GUI
{
    public partial class StudentForm : Form
    {
        bool IsCreateNew = false;

        public delegate void CreateStudent(SV sv);
        public CreateStudent createStudent;

        public delegate void UpdateStudent(SV sv);
        public UpdateStudent updateStudent;

        public StudentForm()
        {
            InitializeComponent();
        }
        public void bindStudentViewModelToForm(StudentViewModel vm)
        {
            txtMSSV.Text = vm.MSSV.ToString();
            txtHoTen.Text = vm.TenSV;
            txtHoKhau.Text = vm.HoKhau;
            txtDiemTB.Text = vm.DiemTB.ToString();
            dtpNgaySinh.Value = vm.NgaySinh.Value;

            if (vm.GioiTinh == true)
            {
                rbnNu.Checked = false;
                rbnNam.Checked = true;
            }
            else if (vm.GioiTinh == false)
            {
                rbnNam.Checked = false;
                rbnNu.Checked = true;
            }
        }
         
        private SV getSVModelFromForm()
        {
            SV sv = new SV();

            int SVID;
            double diemTB;

            bool validID = Int32.TryParse(txtMSSV.Text, out SVID);
            bool validDiemTB = Double.TryParse(txtDiemTB.Text, out diemTB);

            if (!validID)
            {
                MessageBox.Show("Not Valid MSSV.");
                return null;
            }

            if(!validDiemTB)
            {
                MessageBox.Show("Diem Trung Binh Not Valid MSSV.");
                return null;
            }

            sv.MSSV = SVID;
            sv.TenSV = txtHoTen.Text;
            sv.QueQuan = cbxQueQuan.SelectedItem != null ? cbxQueQuan.SelectedItem.ToString() : "";
           
            sv.NgaySinh = dtpNgaySinh.Value;
            sv.HoKhau = txtHoKhau.Text;
            sv.DiemTB = diemTB;

            if (rbnNam.Checked)
            {
                sv.GioiTinh = true;
            }

            if(rbnNu.Checked)
            {
                sv.GioiTinh = false;
            }

            //TODO: Add khoa selected item.
            return sv;
        }
        public void Open(StudentViewModel vm)
        {
            if(vm != null)
            {
                txtMSSV.Enabled = false;
                bindStudentViewModelToForm(vm);
            } else
            {
                IsCreateNew = true;
            }
            this.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SV sv = getSVModelFromForm();

            if (sv == null) return;

            if (IsCreateNew)
            {
                if(createStudent != null)
                {
                    MessageBox.Show("Create new student.");
                    createStudent.Invoke(sv);
                }
            } else
            {
                if (updateStudent != null)
                {
                    MessageBox.Show("Update exits student.");
                    updateStudent.Invoke(sv);
                }
            }
        }
    }
}
