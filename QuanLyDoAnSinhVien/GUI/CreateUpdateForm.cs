using QuanLyDoAnSinhVien.BLL;
using QuanLyDoAnSinhVien.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDoAnSinhVien.GUI
{
    public partial class CreateUpdateForm : Form
    {
        private GVHDBLL gvhdBll = new GVHDBLL();
        private HuongNghienCuuBLL hcnBll = new HuongNghienCuuBLL();
        private DoAnBLL doAnBll = new DoAnBLL();

        public delegate void UpdateData(DoAn da);
        public UpdateData updateData;

        public delegate void CreateData(DoAn da);
        public CreateData createData;

        private bool isCreateNew = false;

        public CreateUpdateForm()
        {
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            foreach (var item in gvhdBll.getAllGVHD())
            {
                cbxGVHD.Items.Add(item);
            }

            foreach (var item in hcnBll.getAllHNC())
            {
                cbxHNC.Items.Add(item);
            }

            for(int i = 1; i <= 100; i ++)
            {
                cbxNamBaoVe.Items.Add(1990 + i);
            }
        }

        public void isCreateNewData(bool select)
        {
            this.isCreateNew = select;
        }

        public void setData(DoAn da)
        {
            txtMaDATN.Text = da.MaDoAn;
            txtSVTH.Text = da.TenSV;
            txtTenDATN.Text = da.TenDoAn;
            
            if (da.TinhTrang)
            {
                rbnDaBaoVe.Select();
            }
            else
            {
                rbnChuaBaoVe.Select();
            }

            prepareComboBox(da);
        }

        private void prepareComboBox(DoAn da)
        {
            GVHD[] gvhds = gvhdBll.getAllGVHD();
            HuongNghienCuu[] hncs = hcnBll.getAllHNC();

            for (int i = 0; i < gvhds.Length; i ++)
            {
                if (da.ID_GVHD == gvhds[i].ID_GVHD)
                {
                    cbxGVHD.SelectedIndex = i;
                    break;
                }
            }

            for (int i = 0; i < hncs.Length; i++)
            {
                if (da.Ma_Huong_NC == hncs[i].Ma_Huong_NC)
                {
                    cbxHNC.SelectedIndex = i;
                    break;
                }
            }

            for (int i = 1; i <= 100; i++)
            {
                if(1990 + i == da.NamThucHien)
                {
                    cbxNamBaoVe.SelectedIndex = i - 1;
                    break;
                }

            }
        }

        private DoAn getFormData()
        {
            DoAn da = new DoAn();
            da.MaDoAn = txtMaDATN.Text;
            da.TenSV = txtSVTH.Text;
            da.TenDoAn = txtTenDATN.Text;
            da.ID_GVHD = ((GVHD)cbxGVHD.SelectedItem).ID_GVHD;
            da.Ma_Huong_NC = ((HuongNghienCuu)cbxHNC.SelectedItem).Ma_Huong_NC;
            da.TinhTrang = true;
            da.NamThucHien = (int) cbxNamBaoVe.SelectedItem;
            return da;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(isCreateNew)
            {
                if (createData != null)
                {
                    createData.Invoke(getFormData());
                    this.Close();
                }
                return;
            } 

            if(updateData != null)
            {
                updateData.Invoke(getFormData());
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
