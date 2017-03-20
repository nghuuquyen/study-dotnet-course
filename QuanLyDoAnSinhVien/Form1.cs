using QuanLyDoAnSinhVien.BLL;
using QuanLyDoAnSinhVien.DTO;
using QuanLyDoAnSinhVien.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDoAnSinhVien
{
    public partial class Form1 : Form
    {
        private GVHDBLL gvhdBll = new GVHDBLL();
        private HuongNghienCuuBLL hcnBll = new HuongNghienCuuBLL();
        private DoAnBLL doAnBll = new DoAnBLL();
        public Form1()
        {
            InitializeComponent();
            InitData();
             
        }

        public void updateData(DoAn da)
        {
            doAnBll.update(da);
            dataGridView.DataSource = doAnBll.getListDoAn();
        }

        public void createData(DoAn da)
        {
            doAnBll.save(da);
            dataGridView.DataSource = doAnBll.getListDoAn();
        }

        private void InitData()
        {
            var doans = doAnBll.getListDoAn();
            var gvhds = gvhdBll.getAllGVHD();
            var hncs = hcnBll.getAllHNC();

            foreach (var item in gvhds)
            {
                cbxGVHD.Items.Add(item);
            }

            foreach (var item in hncs)
            {
                cbxHNC.Items.Add(item);
            }

            dataGridView.DataSource = doAnBll.getListDoAn();

            //for (int i = 0; i < doans.Length; i++)
            //    for (int j = 0; j < gvhds.Length; j++)
            //    {
            //        if (doans[i].ID_GVHD.Trim() == gvhds[j].ID_GVHD.Trim())
            //        {
            //            dataGridView.Rows[i].Cells[5].Value = gvhds[j].Ten.Trim();
            //        }

            //        if (doans[i].Ma_Huong_NC.Trim() == hncs[j].Ma_Huong_NC.Trim())
            //        {
            //            dataGridView.Rows[i].Cells[6].Value = hncs[j].Ten.Trim();
            //        }
            //    }
        }
     

        private DoAn getStudentSelectedFromGridView()
        {
            int index = dataGridView.SelectedCells[0].RowIndex;
            return ((DoAn[])dataGridView.DataSource)[index];
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            CreateUpdateForm form = new CreateUpdateForm();
            form.setData(getStudentSelectedFromGridView());
            form.updateData = new CreateUpdateForm.UpdateData(updateData);
            form.isCreateNewData(false);
            form.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CreateUpdateForm form = new CreateUpdateForm();
            form.createData = new CreateUpdateForm.CreateData(createData);
            form.isCreateNewData(true);
            form.Show();
        }

        private bool GetUserConfirm(string message)
        {
            var confirmResult = MessageBox.Show(message, "Confirm!",
                                     MessageBoxButtons.YesNo);
            return confirmResult == DialogResult.Yes;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!GetUserConfirm("Are you sure to remove !"))
                return;

            doAnBll.remove(getStudentSelectedFromGridView());
            dataGridView.DataSource = doAnBll.getListDoAn();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtSearch.Text == "")
            {
                dataGridView.DataSource = doAnBll.getListDoAn();
                return;
            }

            DoAn[] data = (DoAn[])dataGridView.DataSource;

            data = data.Where(item => item.TenDoAn.Contains(txtSearch.Text.Trim())).ToArray();

            dataGridView.DataSource = data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView.DataSource = doAnBll.getListDoAn();
        }
    }
}
