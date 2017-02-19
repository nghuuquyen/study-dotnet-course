using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentManaging.Models;

namespace StudentManaging
{
    public partial class Form1 : Form
    {
        private ArrayList StudentList = new ArrayList();
        private bool isDuringEditFormData = false;


        public Form1()
        {
            InitializeComponent();
            LockAllFormComponents(true);
        }

        public void UpdateStudentList()
        {
            lvwSinhVien.Items.Clear();
            int i = 0;

            foreach (SinhVien sv in StudentList)
            {
                ListViewItem item = new ListViewItem(sv.MSSV.ToString(), i++);
                item.SubItems.Add(sv.HOTEN);
                item.SubItems.Add(sv.NGAYSINH.ToString());
                item.SubItems.Add(sv.DIACHI);
                item.SubItems.Add(sv.DIENTHOAI.ToString());
                item.SubItems.Add(sv.NIENKHOA.ToString());
                item.SubItems.Add(sv.LoaiHinh());

                lvwSinhVien.Items.Add(item);
            }
        }

        private void OnClickAddStudentButton(object sender, EventArgs e)
        {
            if (isDuringEditFormData)
            {   
                // If saving completed.
                if(SavingNewStudent())
                {
                    isDuringEditFormData = false;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnReset.Enabled = false;
                    LockAllFormComponents(true);
                    btnThem.Text = "Thêm mới";
                    ResetForm();
                }
            }
            else
            {
                isDuringEditFormData = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnReset.Enabled = true;
                btnThem.Text = "Lưu Data";
                btnCancel.Visible = true;
                LockAllFormComponents(false);
                ResetForm();
            }
        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            cboCN.Enabled = false;
            txtBang1.Enabled = false;
            txtCty.Enabled = false;

            if (ctrl.Name == "radDaiHoc")
                cboCN.Enabled = true;
            else if (ctrl.Name == "radBang2")
            {
                txtBang1.Enabled = true;
                txtCty.Enabled = true;
            }
        }

        private void ListView_OnSelectedStudentRow(object sender, EventArgs e)
        {
            if (lvwSinhVien.SelectedItems.Count > 0)
            {
                if (isDuringEditFormData)
                {
                    if (!GetUserConfirm("Bạn đang có dữ liệu chưa lưu.\nCó chắc bạn muốn tiếp tục."))
                        return;
                }

                ListViewItem item = lvwSinhVien.SelectedItems[0];

                txtMSSV.Text = item.SubItems[0].Text;
                txtHoTen.Text = item.SubItems[1].Text;
                dtpNS.Value = DateTime.Parse(item.SubItems[2].Text);
                txtDiaChi.Text = item.SubItems[3].Text;
                txtDienThoai.Text = item.SubItems[4].Text;
                txtNienKhoa.Text = item.SubItems[5].Text;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvwSinhVien.SelectedItems.Count > 0)
            {
                if (!GetUserConfirm("Bạn có chắc là muốn xóa !\nSinh viên đã chọn"))
                    return;

                ListView.SelectedListViewItemCollection selectedList;
                selectedList = lvwSinhVien.SelectedItems;

                foreach (ListViewItem item in selectedList)
                {
                    string ms = item.Text;
                    foreach (SinhVien sv in StudentList)
                    {
                        if (sv.MSSV.ToString() == ms)
                        {
                            StudentList.Remove(sv);
                            break;
                        }
                    }
                }
                UpdateStudentList();
                ResetForm();
            }
            else MessageBox.Show("Bạn chưa chọn sinh viên nào !");
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lvwSinhVien.SelectedItems.Count > 0)
            {
                if (isDuringEditFormData)
                {
                    if (SavingEditStudent())
                    {
                        isDuringEditFormData = false;
                        btnThem.Enabled = true;
                        btnXoa.Enabled = true;
                        btnReset.Enabled = false;
                        LockAllFormComponents(true);
                        btnSua.Text = "Sửa";
                        ResetForm();
                    }
                }
                else
                {
                    isDuringEditFormData = true;
                    btnThem.Enabled = false;
                    btnXoa.Enabled = false;
                    btnReset.Enabled = true;
                    txtMSSV.Enabled = false;
                    btnCancel.Visible = true;
                    LockAllFormComponents(false);
                    btnSua.Text = "Lưu Data";
                }

            }
            else MessageBox.Show("Bạn chưa chọn sinh viên nào !");

        }


        private void LockAllFormComponents(bool state)
        {
            state = !state;

            txtHoTen.Enabled = state;
            txtMSSV.Enabled = state;
            radBang2.Enabled = state;
            radCaoDang.Enabled = state;
            radDaiHoc.Enabled = state;
            txtNienKhoa.Enabled = state;
            dtpNS.Enabled = state;
            txtBang1.Enabled = state;
            txtCty.Enabled = state;
            txtDiaChi.Enabled = state;
            txtDienThoai.Enabled = state;
            cboCN.Enabled = state;
            btnReset.Enabled = state;

            btnCancel.Visible = state;
        }

        private bool SavingNewStudent()
        {
            SinhVien sv = null;

            if (!isValidFormData())
                return false;

            StudentFormData data = getFormData();

            foreach (SinhVien sv1 in StudentList)
            {
                if (sv1.MSSV == data.MaSo)
                {
                    MessageBox.Show("Mã Sinh Viên Đã Tồn Tại", "Message");
                    return false;
                }
            }

            if (radDaiHoc.Checked)
            {
                string chuyenNganh = cboCN.Text;
                sv = new SinhVienDaiHoc(data.DiaChi, data.DienThoai, data.HoTen, data.MaSo,
                                        data.NgaySinh, data.NienKhoa, data.ChuyenNganh);
            }
            else if (radBang2.Checked)
            {
                string bang1 = txtBang1.Text;
                string cty = txtCty.Text;
                sv = new SinhVienBangHai(data.Bang1, cty, data.DiaChi, data.DienThoai, data.HoTen, data.MaSo,
                                         data.NgaySinh, data.NienKhoa);
            }
            else
            {
                sv = new SinhVienCaoDang(data.DiaChi, data.DienThoai, data.HoTen, data.MaSo,
                                         data.NgaySinh, data.NienKhoa);
            }

            StudentList.Add(sv);
            UpdateStudentList();
            return true;
        }

        private bool SavingEditStudent()
        {
            if (!isValidFormData())
                return false;

            StudentFormData data = getFormData();

            foreach (SinhVien sv in StudentList)
            {
                if (sv.MSSV == data.MaSo)
                {
                    sv.DIACHI = data.DiaChi;
                    sv.DIENTHOAI = data.DienThoai;
                    sv.NIENKHOA = data.NienKhoa;
                    sv.NGAYSINH = data.NgaySinh;
                    break;
                }
            }

            UpdateStudentList();
            return true;
        }

        private StudentFormData getFormData()
        {
            StudentFormData data = new StudentFormData();

            data.DienThoai = txtDienThoai.Text;
            data.HoTen = txtHoTen.Text;
            data.MaSo = txtMSSV.Text;
            data.NgaySinh = dtpNS.Value;
            data.NienKhoa = txtNienKhoa.Text;
            data.ChuyenNganh = cboCN.Text;
            data.Bang1 = txtBang1.Text;
            data.Cty = txtCty.Text;
            data.DiaChi = txtDiaChi.Text;

            return data;
        }

        private void ResetForm()
        {
            txtMSSV.Text = "";
            txtHoTen.Text = "";
            txtDienThoai.Text = "";
            txtDiaChi.Text = "";
            txtCty.Text = "";
            txtBang1.Text = "";
            txtNienKhoa.Text = "";
            radBang2.Checked = false;
            radCaoDang.Checked = false;
            radDaiHoc.Checked = false;
            cboCN.Text = "";
            dtpNS.Value = DateTime.Now;
        }

        private bool GetUserConfirm(string message)
        {
            var confirmResult = MessageBox.Show(message, "Confirm!",
                                     MessageBoxButtons.YesNo);
            return confirmResult == DialogResult.Yes;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // If user is seleted list item, reset to default item seleted data.
            if (lvwSinhVien.SelectedItems.Count > 0)
            {
                ListViewItem item = lvwSinhVien.SelectedItems[0];

                txtMSSV.Text = item.SubItems[0].Text;
                txtHoTen.Text = item.SubItems[1].Text;
                dtpNS.Value = DateTime.Parse(item.SubItems[2].Text);
                txtDiaChi.Text = item.SubItems[3].Text;
                txtDienThoai.Text = item.SubItems[4].Text;
                txtNienKhoa.Text = item.SubItems[5].Text;
            }
            else ResetForm();
        }

        private bool isValidFormData()
        {
            if (txtMSSV.Text == "")
            {
                MessageBox.Show("Mã sinh viên không được để trống");
                return false;
            }

            if (dtpNS.Value == null)
            {
                MessageBox.Show("Ngày sinh không được để trống");
                return false;
            }

            if (txtHoTen.Text == "" || txtDiaChi.Text == "" || txtDienThoai.Text == "")
            {
                MessageBox.Show("Ngày sinh , họ tên , điện thoại không được để trống");
                return false;
            }

            return true;
        }

        class StudentFormData
        {
            public string DiaChi { get; set; }
            public string DienThoai { get; set; }
            public string HoTen { get; set; }
            public string MaSo { get; set; }
            public DateTime NgaySinh { get; set; }
            public string NienKhoa { get; set; }
            public string ChuyenNganh { get; set; }
            public string Bang1 { get; set; }
            public string Cty { get; set; }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(GetUserConfirm("Bạn có chắc là muốn hủy bỏ hoạt động ?"))
            {
                ResetForm();
                LockAllFormComponents(true);
                btnThem.Text = "Thêm";
                btnSua.Text = "Sửa";
                isDuringEditFormData = false;
            }
        }
    }
}
