namespace QuanTriTrongOracle
{
    partial class NavSC
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
            this.panel1_NVCB = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Nav_DangKySC = new System.Windows.Forms.Button();
            this.Nav_InfoSC = new System.Windows.Forms.Button();
            this.Nav_HocPhanSC = new System.Windows.Forms.Button();
            this.Nav_KHMOSC = new System.Windows.Forms.Button();
            this.panel2_SC = new System.Windows.Forms.Panel();
            this.Nav_ThongBao = new System.Windows.Forms.Button();
            this.panel1_NVCB.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1_NVCB
            // 
            this.panel1_NVCB.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel1_NVCB.Controls.Add(this.tableLayoutPanel1);
            this.panel1_NVCB.Location = new System.Drawing.Point(0, 2);
            this.panel1_NVCB.Name = "panel1_NVCB";
            this.panel1_NVCB.Size = new System.Drawing.Size(262, 682);
            this.panel1_NVCB.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.Nav_ThongBao, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.Nav_DangKySC, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Nav_InfoSC, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Nav_HocPhanSC, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Nav_KHMOSC, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 122);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(251, 379);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Nav_DangKySC
            // 
            this.Nav_DangKySC.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Nav_DangKySC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nav_DangKySC.Location = new System.Drawing.Point(3, 243);
            this.Nav_DangKySC.Name = "Nav_DangKySC";
            this.Nav_DangKySC.Size = new System.Drawing.Size(245, 57);
            this.Nav_DangKySC.TabIndex = 2;
            this.Nav_DangKySC.Text = "Đăng Ký";
            this.Nav_DangKySC.UseVisualStyleBackColor = false;
            this.Nav_DangKySC.Click += new System.EventHandler(this.Nav_DangKySC_Click);
            // 
            // Nav_InfoSC
            // 
            this.Nav_InfoSC.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Nav_InfoSC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nav_InfoSC.Location = new System.Drawing.Point(3, 3);
            this.Nav_InfoSC.Name = "Nav_InfoSC";
            this.Nav_InfoSC.Size = new System.Drawing.Size(245, 57);
            this.Nav_InfoSC.TabIndex = 0;
            this.Nav_InfoSC.Text = "Xem Thông Tin";
            this.Nav_InfoSC.UseVisualStyleBackColor = false;
            this.Nav_InfoSC.Click += new System.EventHandler(this.Nav_InfoSC_Click);
            // 
            // Nav_HocPhanSC
            // 
            this.Nav_HocPhanSC.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Nav_HocPhanSC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nav_HocPhanSC.Location = new System.Drawing.Point(3, 83);
            this.Nav_HocPhanSC.Name = "Nav_HocPhanSC";
            this.Nav_HocPhanSC.Size = new System.Drawing.Size(245, 57);
            this.Nav_HocPhanSC.TabIndex = 1;
            this.Nav_HocPhanSC.Text = "Học Phần";
            this.Nav_HocPhanSC.UseVisualStyleBackColor = false;
            this.Nav_HocPhanSC.Click += new System.EventHandler(this.Nav_HocPhanSC_Click);
            // 
            // Nav_KHMOSC
            // 
            this.Nav_KHMOSC.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Nav_KHMOSC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nav_KHMOSC.Location = new System.Drawing.Point(3, 163);
            this.Nav_KHMOSC.Name = "Nav_KHMOSC";
            this.Nav_KHMOSC.Size = new System.Drawing.Size(245, 57);
            this.Nav_KHMOSC.TabIndex = 2;
            this.Nav_KHMOSC.Text = "KHMO";
            this.Nav_KHMOSC.UseVisualStyleBackColor = false;
            this.Nav_KHMOSC.Click += new System.EventHandler(this.Nav_KHMOSC_Click);
            // 
            // panel2_SC
            // 
            this.panel2_SC.Location = new System.Drawing.Point(262, 2);
            this.panel2_SC.Name = "panel2_SC";
            this.panel2_SC.Size = new System.Drawing.Size(851, 677);
            this.panel2_SC.TabIndex = 4;
            // 
            // Nav_ThongBao
            // 
            this.Nav_ThongBao.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Nav_ThongBao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nav_ThongBao.Location = new System.Drawing.Point(3, 323);
            this.Nav_ThongBao.Name = "Nav_ThongBao";
            this.Nav_ThongBao.Size = new System.Drawing.Size(245, 53);
            this.Nav_ThongBao.TabIndex = 3;
            this.Nav_ThongBao.Text = "Thông báo";
            this.Nav_ThongBao.UseVisualStyleBackColor = false;
            this.Nav_ThongBao.Click += new System.EventHandler(this.Nav_ThongBao_Click);
            // 
            // NavSC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 680);
            this.Controls.Add(this.panel2_SC);
            this.Controls.Add(this.panel1_NVCB);
            this.Name = "NavSC";
            this.Text = "NavSC";
            this.panel1_NVCB.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1_NVCB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button Nav_DangKySC;
        private System.Windows.Forms.Button Nav_InfoSC;
        private System.Windows.Forms.Button Nav_HocPhanSC;
        private System.Windows.Forms.Button Nav_KHMOSC;
        private System.Windows.Forms.Panel panel2_SC;
        private System.Windows.Forms.Button Nav_ThongBao;
    }
}