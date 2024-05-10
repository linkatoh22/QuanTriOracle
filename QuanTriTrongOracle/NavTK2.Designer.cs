namespace QuanTriTrongOracle
{
    partial class NavTK2
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Nav_DangKy = new System.Windows.Forms.Button();
            this.Nav_NhanSu = new System.Windows.Forms.Button();
            this.Nav_PhanCong = new System.Windows.Forms.Button();
            this.Nav_MNhanSu = new System.Windows.Forms.Button();
            this.Nav_All = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(337, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(953, 765);
            this.panel2.TabIndex = 5;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(337, 765);
            this.panel1.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.Nav_All, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.Nav_MNhanSu, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Nav_PhanCong, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Nav_DangKy, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Nav_NhanSu, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 129);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00363F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00002F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.99821F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.99813F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(335, 454);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Nav_DangKy
            // 
            this.Nav_DangKy.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Nav_DangKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nav_DangKy.Location = new System.Drawing.Point(4, 93);
            this.Nav_DangKy.Margin = new System.Windows.Forms.Padding(4);
            this.Nav_DangKy.Name = "Nav_DangKy";
            this.Nav_DangKy.Size = new System.Drawing.Size(324, 69);
            this.Nav_DangKy.TabIndex = 5;
            this.Nav_DangKy.Text = "Đăng ký";
            this.Nav_DangKy.UseVisualStyleBackColor = false;
            this.Nav_DangKy.Click += new System.EventHandler(this.Nav_DangKy_Click);
            // 
            // Nav_NhanSu
            // 
            this.Nav_NhanSu.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Nav_NhanSu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nav_NhanSu.Location = new System.Drawing.Point(4, 4);
            this.Nav_NhanSu.Margin = new System.Windows.Forms.Padding(4);
            this.Nav_NhanSu.Name = "Nav_NhanSu";
            this.Nav_NhanSu.Size = new System.Drawing.Size(327, 69);
            this.Nav_NhanSu.TabIndex = 0;
            this.Nav_NhanSu.Text = "Xem thông tin cá nhân";
            this.Nav_NhanSu.UseVisualStyleBackColor = false;
            this.Nav_NhanSu.Click += new System.EventHandler(this.Nav_NhanSu_Click);
            // 
            // Nav_PhanCong
            // 
            this.Nav_PhanCong.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Nav_PhanCong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nav_PhanCong.Location = new System.Drawing.Point(4, 182);
            this.Nav_PhanCong.Margin = new System.Windows.Forms.Padding(4);
            this.Nav_PhanCong.Name = "Nav_PhanCong";
            this.Nav_PhanCong.Size = new System.Drawing.Size(324, 73);
            this.Nav_PhanCong.TabIndex = 6;
            this.Nav_PhanCong.Text = "Phân công";
            this.Nav_PhanCong.UseVisualStyleBackColor = false;
            this.Nav_PhanCong.Click += new System.EventHandler(this.Nav_PhanCong_Click);
            // 
            // Nav_MNhanSu
            // 
            this.Nav_MNhanSu.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Nav_MNhanSu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nav_MNhanSu.Location = new System.Drawing.Point(4, 271);
            this.Nav_MNhanSu.Margin = new System.Windows.Forms.Padding(4);
            this.Nav_MNhanSu.Name = "Nav_MNhanSu";
            this.Nav_MNhanSu.Size = new System.Drawing.Size(324, 73);
            this.Nav_MNhanSu.TabIndex = 7;
            this.Nav_MNhanSu.Text = "Nhân sự";
            this.Nav_MNhanSu.UseVisualStyleBackColor = false;
            this.Nav_MNhanSu.Click += new System.EventHandler(this.Nav_MNhanSu_Click);
            // 
            // Nav_All
            // 
            this.Nav_All.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Nav_All.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nav_All.Location = new System.Drawing.Point(4, 360);
            this.Nav_All.Margin = new System.Windows.Forms.Padding(4);
            this.Nav_All.Name = "Nav_All";
            this.Nav_All.Size = new System.Drawing.Size(324, 73);
            this.Nav_All.TabIndex = 8;
            this.Nav_All.Text = "Xem CSDL";
            this.Nav_All.UseVisualStyleBackColor = false;
            this.Nav_All.Click += new System.EventHandler(this.Nav_All_Click);
            // 
            // NavTK2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1282, 765);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "NavTK2";
            this.Text = "NavTK2";
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button Nav_DangKy;
        private System.Windows.Forms.Button Nav_NhanSu;
        private System.Windows.Forms.Button Nav_PhanCong;
        private System.Windows.Forms.Button Nav_All;
        private System.Windows.Forms.Button Nav_MNhanSu;
    }
}