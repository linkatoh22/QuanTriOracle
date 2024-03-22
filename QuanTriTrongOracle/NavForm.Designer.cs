namespace QuanTriTrongOracle
{
    partial class NavForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Nav_PhanQuyen = new System.Windows.Forms.Button();
            this.Nav_XemUser = new System.Windows.Forms.Button();
            this.Nav_XemPriv = new System.Windows.Forms.Button();
            this.Nav_EditUserRole = new System.Windows.Forms.Button();
            this.Nav_ThuHoiQuyen = new System.Windows.Forms.Button();
            this.Nav_DetailUser = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(253, 682);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.Nav_PhanQuyen, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Nav_XemUser, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Nav_XemPriv, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Nav_EditUserRole, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Nav_ThuHoiQuyen, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.Nav_DetailUser, 0, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 105);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(251, 379);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // Nav_PhanQuyen
            // 
            this.Nav_PhanQuyen.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Nav_PhanQuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nav_PhanQuyen.Location = new System.Drawing.Point(3, 192);
            this.Nav_PhanQuyen.Name = "Nav_PhanQuyen";
            this.Nav_PhanQuyen.Size = new System.Drawing.Size(245, 57);
            this.Nav_PhanQuyen.TabIndex = 2;
            this.Nav_PhanQuyen.Text = "Phân Quyền";
            this.Nav_PhanQuyen.UseVisualStyleBackColor = false;
            this.Nav_PhanQuyen.Click += new System.EventHandler(this.Nav_PhanQuyen_Click);
            // 
            // Nav_XemUser
            // 
            this.Nav_XemUser.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Nav_XemUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nav_XemUser.Location = new System.Drawing.Point(3, 3);
            this.Nav_XemUser.Name = "Nav_XemUser";
            this.Nav_XemUser.Size = new System.Drawing.Size(245, 57);
            this.Nav_XemUser.TabIndex = 0;
            this.Nav_XemUser.Text = "Xem danh sách User";
            this.Nav_XemUser.UseVisualStyleBackColor = false;
            this.Nav_XemUser.Click += new System.EventHandler(this.Nav_XemUser_Click);
            // 
            // Nav_XemPriv
            // 
            this.Nav_XemPriv.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Nav_XemPriv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nav_XemPriv.Location = new System.Drawing.Point(3, 66);
            this.Nav_XemPriv.Name = "Nav_XemPriv";
            this.Nav_XemPriv.Size = new System.Drawing.Size(245, 57);
            this.Nav_XemPriv.TabIndex = 1;
            this.Nav_XemPriv.Text = "Xem quyền";
            this.Nav_XemPriv.UseVisualStyleBackColor = false;
            this.Nav_XemPriv.Click += new System.EventHandler(this.Nav_XemPriv_Click);
            // 
            // Nav_EditUserRole
            // 
            this.Nav_EditUserRole.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Nav_EditUserRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nav_EditUserRole.Location = new System.Drawing.Point(3, 129);
            this.Nav_EditUserRole.Name = "Nav_EditUserRole";
            this.Nav_EditUserRole.Size = new System.Drawing.Size(245, 57);
            this.Nav_EditUserRole.TabIndex = 2;
            this.Nav_EditUserRole.Text = "Thêm, xóa, sửa User/ Role";
            this.Nav_EditUserRole.UseVisualStyleBackColor = false;
            this.Nav_EditUserRole.Click += new System.EventHandler(this.Nav_EditUserRole_Click);
            // 
            // Nav_ThuHoiQuyen
            // 
            this.Nav_ThuHoiQuyen.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Nav_ThuHoiQuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nav_ThuHoiQuyen.Location = new System.Drawing.Point(3, 255);
            this.Nav_ThuHoiQuyen.Name = "Nav_ThuHoiQuyen";
            this.Nav_ThuHoiQuyen.Size = new System.Drawing.Size(245, 57);
            this.Nav_ThuHoiQuyen.TabIndex = 3;
            this.Nav_ThuHoiQuyen.Text = "Thu hồi quyền";
            this.Nav_ThuHoiQuyen.UseVisualStyleBackColor = false;
            this.Nav_ThuHoiQuyen.Click += new System.EventHandler(this.Nav_ThuHoiQuyen_Click);
            // 
            // Nav_DetailUser
            // 
            this.Nav_DetailUser.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Nav_DetailUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nav_DetailUser.Location = new System.Drawing.Point(3, 318);
            this.Nav_DetailUser.Name = "Nav_DetailUser";
            this.Nav_DetailUser.Size = new System.Drawing.Size(243, 58);
            this.Nav_DetailUser.TabIndex = 4;
            this.Nav_DetailUser.Text = "Kiểm tra quyền";
            this.Nav_DetailUser.UseVisualStyleBackColor = false;
            this.Nav_DetailUser.Click += new System.EventHandler(this.Nav_DetailUser_Click);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(252, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(853, 684);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // NavForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 680);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "NavForm";
            this.Text = "EditUserRole";
            this.Load += new System.EventHandler(this.EditUserRole_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button Nav_XemUser;
        private System.Windows.Forms.Button Nav_XemPriv;
        private System.Windows.Forms.Button Nav_EditUserRole;
        private System.Windows.Forms.Button Nav_PhanQuyen;
        private System.Windows.Forms.Button Nav_ThuHoiQuyen;
        private System.Windows.Forms.Button Nav_DetailUser;
    }
}