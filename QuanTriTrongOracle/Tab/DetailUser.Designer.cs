namespace QuanTriTrongOracle.Tab
{
    partial class DetailUser
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
            this.UserDD = new System.Windows.Forms.ComboBox();
            this.Userlbl = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ObjectRad = new System.Windows.Forms.RadioButton();
            this.SystemRad = new System.Windows.Forms.RadioButton();
            this.PriList = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PriList)).BeginInit();
            this.SuspendLayout();
            // 
            // UserDD
            // 
            this.UserDD.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.UserDD.FormattingEnabled = true;
            this.UserDD.Location = new System.Drawing.Point(387, 101);
            this.UserDD.Name = "UserDD";
            this.UserDD.Size = new System.Drawing.Size(232, 24);
            this.UserDD.TabIndex = 38; 
            this.UserDD.SelectedIndexChanged += new System.EventHandler(this.SystemUserDD_SelectedIndexChanged);
            // 
            // Userlbl
            // 
            this.Userlbl.AutoSize = true;
            this.Userlbl.Enabled = false;
            this.Userlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Userlbl.Location = new System.Drawing.Point(276, 99);
            this.Userlbl.Name = "Userlbl";
            this.Userlbl.Size = new System.Drawing.Size(100, 22);
            this.Userlbl.TabIndex = 37;
            this.Userlbl.Text = "User / Role";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.ObjectRad);
            this.groupBox1.Controls.Add(this.SystemRad);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(151, 188);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(647, 52);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            // 
            // ObjectRad
            // 
            this.ObjectRad.AutoSize = true;
            this.ObjectRad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ObjectRad.Location = new System.Drawing.Point(399, 14);
            this.ObjectRad.Name = "ObjectRad";
            this.ObjectRad.Size = new System.Drawing.Size(178, 26);
            this.ObjectRad.TabIndex = 1;
            this.ObjectRad.Text = "Quyền đối tượng";
            this.ObjectRad.UseVisualStyleBackColor = true;
            this.ObjectRad.CheckedChanged += new System.EventHandler(this.ObjectPriRadio_CheckedChanged);
            // 
            // SystemRad
            // 
            this.SystemRad.AutoSize = true;
            this.SystemRad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SystemRad.Location = new System.Drawing.Point(88, 16);
            this.SystemRad.Name = "SystemRad";
            this.SystemRad.Size = new System.Drawing.Size(161, 24);
            this.SystemRad.TabIndex = 0;
            this.SystemRad.Text = "Quyền hệ thống";
            this.SystemRad.UseVisualStyleBackColor = true;
            this.SystemRad.CheckedChanged += new System.EventHandler(this.SystemPriRadio_CheckedChanged);
            // 
            // PriList
            // 
            this.PriList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PriList.Location = new System.Drawing.Point(54, 256);
            this.PriList.Name = "PriList";
            this.PriList.RowHeadersWidth = 51;
            this.PriList.RowTemplate.Height = 24;
            this.PriList.Size = new System.Drawing.Size(842, 412);
            this.PriList.TabIndex = 50;
            // 
            // DetailUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PriList);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.UserDD);
            this.Controls.Add(this.Userlbl);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DetailUser";
            this.Size = new System.Drawing.Size(1137, 842);
            this.Load += new System.EventHandler(this.DetailUser_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PriList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox UserDD;
        private System.Windows.Forms.Label Userlbl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton ObjectRad;
        private System.Windows.Forms.RadioButton SystemRad;
        private System.Windows.Forms.DataGridView PriList;
    }
}
