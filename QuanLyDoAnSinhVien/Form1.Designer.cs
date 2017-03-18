namespace QuanLyDoAnSinhVien
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridView dgvDoAn;
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten_Do_An = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten_SV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HuongNC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GVHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tinh_Trang = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NamBaoVe = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.qLDoAnDataSetBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.qL_Do_AnDataSet = new QuanLyDoAnSinhVien.QL_Do_AnDataSet();
            this.qLDoAnDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbxHNC = new System.Windows.Forms.ComboBox();
            this.cbxTinhTrang = new System.Windows.Forms.ComboBox();
            this.cbxGVHD = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            dgvDoAn = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(dgvDoAn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLDoAnDataSetBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qL_Do_AnDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLDoAnDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDoAn
            // 
            dgvDoAn.AutoGenerateColumns = false;
            dgvDoAn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDoAn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.Ten_Do_An,
            this.Ten_SV,
            this.HuongNC,
            this.GVHD,
            this.Tinh_Trang,
            this.NamBaoVe});
            dgvDoAn.DataSource = this.qLDoAnDataSetBindingSource1;
            dgvDoAn.Location = new System.Drawing.Point(12, 38);
            dgvDoAn.Name = "dgvDoAn";
            dgvDoAn.Size = new System.Drawing.Size(901, 228);
            dgvDoAn.TabIndex = 0;
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            // 
            // Ten_Do_An
            // 
            this.Ten_Do_An.HeaderText = "Tên Đề Tài";
            this.Ten_Do_An.Name = "Ten_Do_An";
            // 
            // Ten_SV
            // 
            this.Ten_SV.HeaderText = "SV Thực Hiện";
            this.Ten_SV.Name = "Ten_SV";
            // 
            // HuongNC
            // 
            this.HuongNC.HeaderText = "Hướng NC";
            this.HuongNC.Name = "HuongNC";
            // 
            // GVHD
            // 
            this.GVHD.HeaderText = "GVHD";
            this.GVHD.Name = "GVHD";
            // 
            // Tinh_Trang
            // 
            this.Tinh_Trang.HeaderText = "Tình Trạng";
            this.Tinh_Trang.Name = "Tinh_Trang";
            // 
            // NamBaoVe
            // 
            this.NamBaoVe.HeaderText = "Năm Bảo Vệ";
            this.NamBaoVe.Items.AddRange(new object[] {
            "2015",
            "2016",
            "2017",
            "2018",
            "2019"});
            this.NamBaoVe.Name = "NamBaoVe";
            // 
            // qLDoAnDataSetBindingSource1
            // 
            this.qLDoAnDataSetBindingSource1.DataSource = this.qL_Do_AnDataSet;
            this.qLDoAnDataSetBindingSource1.Position = 0;
            // 
            // qL_Do_AnDataSet
            // 
            this.qL_Do_AnDataSet.DataSetName = "QL_Do_AnDataSet";
            this.qL_Do_AnDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // qLDoAnDataSetBindingSource
            // 
            this.qLDoAnDataSetBindingSource.DataSource = this.qL_Do_AnDataSet;
            this.qLDoAnDataSetBindingSource.Position = 0;
            // 
            // cbxHNC
            // 
            this.cbxHNC.FormattingEnabled = true;
            this.cbxHNC.Location = new System.Drawing.Point(721, 287);
            this.cbxHNC.Name = "cbxHNC";
            this.cbxHNC.Size = new System.Drawing.Size(192, 21);
            this.cbxHNC.TabIndex = 1;
            // 
            // cbxTinhTrang
            // 
            this.cbxTinhTrang.FormattingEnabled = true;
            this.cbxTinhTrang.Location = new System.Drawing.Point(721, 334);
            this.cbxTinhTrang.Name = "cbxTinhTrang";
            this.cbxTinhTrang.Size = new System.Drawing.Size(192, 21);
            this.cbxTinhTrang.TabIndex = 2;
            // 
            // cbxGVHD
            // 
            this.cbxGVHD.FormattingEnabled = true;
            this.cbxGVHD.Location = new System.Drawing.Point(721, 379);
            this.cbxGVHD.Name = "cbxGVHD";
            this.cbxGVHD.Size = new System.Drawing.Size(192, 21);
            this.cbxGVHD.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(649, 290);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Hướng NC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(647, 334);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tình Trạng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(668, 382);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "GVHD";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(13, 309);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(118, 309);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(230, 309);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(13, 359);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(118, 362);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(187, 20);
            this.txtSearch.TabIndex = 11;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(13, 426);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(900, 150);
            this.dataGridView.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 658);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxGVHD);
            this.Controls.Add(this.cbxTinhTrang);
            this.Controls.Add(this.cbxHNC);
            this.Controls.Add(dgvDoAn);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(dgvDoAn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLDoAnDataSetBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qL_Do_AnDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLDoAnDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource qLDoAnDataSetBindingSource;
        private QL_Do_AnDataSet qL_Do_AnDataSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten_Do_An;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten_SV;
        private System.Windows.Forms.DataGridViewTextBoxColumn HuongNC;
        private System.Windows.Forms.DataGridViewTextBoxColumn GVHD;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Tinh_Trang;
        private System.Windows.Forms.DataGridViewComboBoxColumn NamBaoVe;
        private System.Windows.Forms.ComboBox cbxHNC;
        private System.Windows.Forms.ComboBox cbxTinhTrang;
        private System.Windows.Forms.ComboBox cbxGVHD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.BindingSource qLDoAnDataSetBindingSource1;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}

