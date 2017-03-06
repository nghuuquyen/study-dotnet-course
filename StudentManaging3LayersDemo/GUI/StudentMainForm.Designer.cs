namespace StudentManaging3LayersDemo.GUI
{
    partial class StudentMainForm
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
            this.lbxStudent = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbxStudent
            // 
            this.lbxStudent.FormattingEnabled = true;
            this.lbxStudent.Location = new System.Drawing.Point(36, 71);
            this.lbxStudent.Name = "lbxStudent";
            this.lbxStudent.Size = new System.Drawing.Size(312, 95);
            this.lbxStudent.TabIndex = 0;
            // 
            // StudentMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 349);
            this.Controls.Add(this.lbxStudent);
            this.Name = "StudentMainForm";
            this.Text = "StudentMainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxStudent;
    }
}