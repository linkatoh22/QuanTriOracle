namespace QuanTriTrongOracle.TabGVU
{
    partial class GVU_NhanSu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.UpdateNSBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SDTUpdTxt = new System.Windows.Forms.TextBox();
            this.LoadNSBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ProfileDataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ProfileDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // UpdateNSBtn
            // 
            this.UpdateNSBtn.Location = new System.Drawing.Point(371, 276);
            this.UpdateNSBtn.Name = "UpdateNSBtn";
            this.UpdateNSBtn.Size = new System.Drawing.Size(103, 23);
            this.UpdateNSBtn.TabIndex = 14;
            this.UpdateNSBtn.Text = "Cập nhật";
            this.UpdateNSBtn.UseVisualStyleBackColor = true;
            this.UpdateNSBtn.Click += new System.EventHandler(this.UpdateNSBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Nhập SĐT mới:";
            // 
            // SDTUpdTxt
            // 
            this.SDTUpdTxt.Location = new System.Drawing.Point(181, 277);
            this.SDTUpdTxt.Name = "SDTUpdTxt";
            this.SDTUpdTxt.Size = new System.Drawing.Size(170, 22);
            this.SDTUpdTxt.TabIndex = 12;
            // 
            // LoadNSBtn
            // 
            this.LoadNSBtn.Location = new System.Drawing.Point(716, 37);
            this.LoadNSBtn.Name = "LoadNSBtn";
            this.LoadNSBtn.Size = new System.Drawing.Size(103, 23);
            this.LoadNSBtn.TabIndex = 11;
            this.LoadNSBtn.Text = "Load data";
            this.LoadNSBtn.UseVisualStyleBackColor = true;
            this.LoadNSBtn.Click += new System.EventHandler(this.LoadNSBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 233);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "Chỉnh sửa SĐT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(75, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Thông tin cá nhân";
            // 
            // ProfileDataGrid
            // 
            this.ProfileDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProfileDataGrid.Location = new System.Drawing.Point(80, 66);
            this.ProfileDataGrid.Name = "ProfileDataGrid";
            this.ProfileDataGrid.RowHeadersWidth = 51;
            this.ProfileDataGrid.RowTemplate.Height = 24;
            this.ProfileDataGrid.Size = new System.Drawing.Size(739, 97);
            this.ProfileDataGrid.TabIndex = 8;
            // 
            // GVU_NhanSu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.UpdateNSBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SDTUpdTxt);
            this.Controls.Add(this.LoadNSBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ProfileDataGrid);
            this.Name = "GVU_NhanSu";
            this.Size = new System.Drawing.Size(865, 331);
            ((System.ComponentModel.ISupportInitialize)(this.ProfileDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UpdateNSBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SDTUpdTxt;
        private System.Windows.Forms.Button LoadNSBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView ProfileDataGrid;
    }
}
