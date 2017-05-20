using FinalProject_QuanLySinhVien.BLL;
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
        KhoaBLL khoaBLL = new KhoaBLL();
        bool IsCreateNew = false;

        public delegate void CreateStudent(SV sv);
        public CreateStudent createStudent;

        public delegate void UpdateStudent(SV sv);
        public UpdateStudent updateStudent;

        public StudentForm()
        {
            InitializeComponent();
            loadListKhoaToComboBox();
        }

        public void loadListKhoaToComboBox()
        {
            cbxKhoa.ValueMember = "MaKhoa";
            cbxKhoa.DisplayMember = "Ten";
            cbxKhoa.DataSource = khoaBLL.getAll();
        }

        public void bindStudentViewModelToForm(StudentViewModel vm)
        {
            txtMSSV.Text = vm.MSSV.ToString();
            txtHoTen.Text = vm.TenSV;
            txtHoKhau.Text = vm.HoKhau;
            txtDiemTB.Text = vm.DiemTB.ToString();
            dtpNgaySinh.Value = vm.NgaySinh.Value;
            if(vm.MaKhoa != null)
                cbxKhoa.SelectedValue = vm.MaKhoa;

            cbxQueQuan.SelectedValue = vm.QueQuan;

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

            int MaKhoa;
            int SVID;
            double diemTB;

            bool validID = Int32.TryParse(txtMSSV.Text, out SVID);
            bool validMaKhoa = Int32.TryParse(cbxKhoa.SelectedValue.ToString(), out MaKhoa);
            bool validDiemTB = Double.TryParse(txtDiemTB.Text, out diemTB);

            if (!validID && IsCreateNew == false)
            {
                MessageBox.Show("Not Valid MSSV.");
                return null;
            }

            if(!validDiemTB)
            {
                MessageBox.Show("Diem Trung Binh Not Valid MSSV.");
                return null;
            }

            if(!validMaKhoa || cbxKhoa.SelectedValue == null)
            {
                MessageBox.Show("Khoa not valid or empty.");
                return null;
            }

            if(IsCreateNew == false)
            {
                sv.MSSV = SVID;
            }

            sv.TenSV = txtHoTen.Text;
            sv.QueQuan = cbxQueQuan.SelectedItem != null ? cbxQueQuan.SelectedItem.ToString() : "";
           
            sv.NgaySinh = dtpNgaySinh.Value;
            sv.HoKhau = txtHoKhau.Text;
            sv.DiemTB = diemTB;
            sv.MaKhoa = MaKhoa;

            if (rbnNam.Checked)
            {
                sv.GioiTinh = true;
            }

            if(rbnNu.Checked)
            {
                sv.GioiTinh = false;
            }

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
                    this.Close();
                }
            } else
            {
                if (updateStudent != null)
                {
                    MessageBox.Show("Update exits student.");
                    updateStudent.Invoke(sv);
                    this.Close();
                }
            }
        }
    }
}
