using FinalProject_QuanLySinhVien.BLL;
using FinalProject_QuanLySinhVien.DAL;
using FinalProject_QuanLySinhVien.GUI;
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

namespace FinalProject_QuanLySinhVien
{
    public partial class MainForm : Form
    {
        SVBLL svBLL = new SVBLL();
        public MainForm()
        {
            InitializeComponent();
            dvgSinhVien.AutoGenerateColumns = false;
            LoadALLStudentToDataGrid();
        }

        public void LoadALLStudentToDataGrid()
        {
            using (var db = new StudentDB())
            {
                dvgSinhVien.DataSource = svBLL.getDataGridViewModel();
            }
            dvgSinhVien.Refresh();
            dvgSinhVien.Update();
        }

        public StudentViewModel getSelectedStudentViewModelFromGrid()
        {
            if (dvgSinhVien.SelectedCells.Count > 0)
            {
                int rowIndex = dvgSinhVien.SelectedCells[0].RowIndex;
                int SVID;
                bool validID = Int32.TryParse(dvgSinhVien.Rows[rowIndex].Cells["MSSV"].Value.ToString(), out SVID);

                if (validID)
                {
                    return svBLL.getStudentViewModelByID(SVID);
                }
            }
            return null;
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

        private void dvgSinhVien_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            StudentForm form = new StudentForm();
            form.Open(getSelectedStudentViewModelFromGrid());
            
            form.createStudent = new StudentForm.CreateStudent(CreateStudent);
            form.updateStudent = new StudentForm.UpdateStudent(UpdateStudent);
        }

        private void dvgSinhVien_MouseClick(object sender, MouseEventArgs e)
        {
            bindStudentViewModelToForm(getSelectedStudentViewModelFromGrid());
        }

        public void UpdateStudent(SV sv)
        {
            svBLL.update(sv);
            LoadALLStudentToDataGrid();
        }

        public void CreateStudent(SV sv)
        {
            svBLL.create(sv);
            LoadALLStudentToDataGrid();
        }
    }
}
