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
        KhoaBLL khoaBLL = new KhoaBLL();
        SVBLL svBLL = new SVBLL();

        public delegate bool ComparerObj(object o1, object o2);


        void Sort(object[] list, ComparerObj cmp)
        {
            for (int i = 0; i < list.Length - 1; i++)
            {
                for (int j = i + 1; j < list.Length; j++)
                {
                    if (cmp(list[i], list[j]))
                    {
                        object temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
        }

        public MainForm()
        {
            InitializeComponent();
            dvgSinhVien.AutoGenerateColumns = false;
            dvgSinhVien.MultiSelect = true;
            LoadALLStudentToDataGrid();
            loadListKhoaToComboBox();
        }

        public void loadListKhoaToComboBox()
        {
            cbxKhoa.ValueMember = "MaKhoa";
            cbxKhoa.DisplayMember = "Ten";
            cbxKhoa.DataSource = khoaBLL.getAll();
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

            cbxQueQuan.SelectedValue = vm.QueQuan;

            if (vm.MaKhoa != null)
                cbxKhoa.SelectedValue = vm.MaKhoa;

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            StudentForm form = new StudentForm();
            form.Open(null);

            form.createStudent = new StudentForm.CreateStudent(CreateStudent);
            form.updateStudent = new StudentForm.UpdateStudent(UpdateStudent);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != null)
            {
                List<SV> searchResules = svBLL.findByName(txtSearch.Text);
                List<StudentViewModel> results = new List<StudentViewModel>();
                foreach (var sv in searchResules)
                {
                    results.Add(svBLL.coverSVToStudentViewModel(sv));
                }

                dvgSinhVien.DataSource = results;
                dvgSinhVien.Refresh();
                dvgSinhVien.Update();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadALLStudentToDataGrid();
        }

        private void ShowSortResult(SV[] datas)
        {

            List<StudentViewModel> results = new List<StudentViewModel>();
            foreach (var sv in datas)
            {
                results.Add(svBLL.coverSVToStudentViewModel(sv));
            }

            dvgSinhVien.DataSource = results;
            dvgSinhVien.Refresh();
            dvgSinhVien.Update();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            // Index 0 : Sort by MSSV.
            // Index 1 : Sort by student name.
            // Index 2 : Sort by Khoa name.
            // Index 3 : Sort by Diem TB.

            if (cbxSort.SelectedIndex == -1)
            {
                MessageBox.Show("Please , choose sort method.");
                return;
            }

            SV[] results = svBLL.getAll().ToArray();

            switch (cbxSort.SelectedIndex)
            {
                case 0:
                    ComparerObj cmp_1 = new ComparerObj(SVBLL.CompareMSSV);
                    this.Sort(results, cmp_1);
                    ShowSortResult(results);
                    break;
                case 1:
                    ComparerObj cmp_2 = new ComparerObj(SVBLL.CompareStudentName);
                    this.Sort(results, cmp_2);
                    ShowSortResult(results);
                    break;
                case 2:
                    ComparerObj cmp_3 = new ComparerObj(SVBLL.CompareKhoaName);
                    this.Sort(results, cmp_3);
                    ShowSortResult(results);
                    break;
                case 3:
                    ComparerObj cmp_4 = new ComparerObj(SVBLL.CompareDiemTB);
                    this.Sort(results, cmp_4);
                    ShowSortResult(results);
                    break;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dvgSinhVien.SelectedCells.Count > 0)
            {
                foreach (DataGridViewRow row in dvgSinhVien.SelectedRows)
                {
                    int SVID;
                    bool validID = Int32.TryParse(dvgSinhVien.Rows[row.Index].Cells["MSSV"].Value.ToString(), out SVID);

                    if (validID)
                    {
                        svBLL.remove(svBLL.findByID(SVID));
                    }
                }
                MessageBox.Show("Delete Completed");
                LoadALLStudentToDataGrid();
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            bindStudentViewModelToForm(getSelectedStudentViewModelFromGrid());
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            StudentForm form = new StudentForm();
            form.Open(getSelectedStudentViewModelFromGrid());

            form.createStudent = new StudentForm.CreateStudent(CreateStudent);
            form.updateStudent = new StudentForm.UpdateStudent(UpdateStudent);
        }
    }
}
