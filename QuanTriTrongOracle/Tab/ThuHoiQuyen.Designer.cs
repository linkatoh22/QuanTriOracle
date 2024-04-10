using System;

namespace QuanTriTrongOracle.Tab
{
    partial class ThuHoiQuyen
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ObjectPriRadio = new System.Windows.Forms.RadioButton();
            this.SystemPriRadio = new System.Windows.Forms.RadioButton();
            this.ObjPriBtn = new System.Windows.Forms.Button();
            this.SystemBtnPri = new System.Windows.Forms.Button();
            this.ObjectPriTxt = new System.Windows.Forms.Label();
            this.ObjectPriDD = new System.Windows.Forms.ComboBox();
            this.ObjectObjDD = new System.Windows.Forms.ComboBox();
            this.ObjectObjTxt = new System.Windows.Forms.Label();
            this.ObjectUserDD = new System.Windows.Forms.ComboBox();
            this.ObjectUserPriTxt = new System.Windows.Forms.Label();
            this.ObjectPriRadioLb = new System.Windows.Forms.Label();
            this.SystemPriDD = new System.Windows.Forms.ComboBox();
            this.SystemPriTxt = new System.Windows.Forms.Label();
            this.SystemUserDD = new System.Windows.Forms.ComboBox();
            this.SystemUserlbl = new System.Windows.Forms.Label();
            this.SystemPriRadioLb = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.ObjectPriRadio);
            this.groupBox1.Controls.Add(this.SystemPriRadio);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(205, 178);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(647, 52);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            // 
            // ObjectPriRadio
            // 
            this.ObjectPriRadio.AutoSize = true;
            this.ObjectPriRadio.Location = new System.Drawing.Point(517, 21);
            this.ObjectPriRadio.Name = "ObjectPriRadio";
            this.ObjectPriRadio.Size = new System.Drawing.Size(17, 16);
            this.ObjectPriRadio.TabIndex = 1;
            this.ObjectPriRadio.TabStop = true;
            this.ObjectPriRadio.UseVisualStyleBackColor = true;
            this.ObjectPriRadio.CheckedChanged += new System.EventHandler(this.ObjectPriRadio_CheckedChanged);
            // 
            // SystemPriRadio
            // 
            this.SystemPriRadio.AutoSize = true;
            this.SystemPriRadio.Location = new System.Drawing.Point(122, 21);
            this.SystemPriRadio.Name = "SystemPriRadio";
            this.SystemPriRadio.Size = new System.Drawing.Size(17, 16);
            this.SystemPriRadio.TabIndex = 0;
            this.SystemPriRadio.TabStop = true;
            this.SystemPriRadio.UseVisualStyleBackColor = true;
            this.SystemPriRadio.CheckedChanged += new System.EventHandler(this.SystemPriRadio_CheckedChanged);
            // 
            // ObjPriBtn
            // 
            this.ObjPriBtn.Enabled = false;
            this.ObjPriBtn.Location = new System.Drawing.Point(707, 519);
            this.ObjPriBtn.Name = "ObjPriBtn";
            this.ObjPriBtn.Size = new System.Drawing.Size(75, 23);
            this.ObjPriBtn.TabIndex = 47;
            this.ObjPriBtn.Text = "Thu hồi";
            this.ObjPriBtn.UseVisualStyleBackColor = true;
            this.ObjPriBtn.Click += new System.EventHandler(this.ObjectBtnPri_Click);
            // 
            // SystemBtnPri
            // 
            this.SystemBtnPri.Enabled = false;
            this.SystemBtnPri.Location = new System.Drawing.Point(327, 519);
            this.SystemBtnPri.Name = "SystemBtnPri";
            this.SystemBtnPri.Size = new System.Drawing.Size(75, 23);
            this.SystemBtnPri.TabIndex = 46;
            this.SystemBtnPri.Text = "Thu hồi";
            this.SystemBtnPri.UseVisualStyleBackColor = true;
            this.SystemBtnPri.Click += new System.EventHandler(this.SystemBtnPri_Click);
            // 
            // ObjectPriTxt
            // 
            this.ObjectPriTxt.Enabled = false;
            this.ObjectPriTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ObjectPriTxt.Location = new System.Drawing.Point(587, 426);
            this.ObjectPriTxt.Name = "ObjectPriTxt";
            this.ObjectPriTxt.Size = new System.Drawing.Size(105, 50);
            this.ObjectPriTxt.TabIndex = 45;
            this.ObjectPriTxt.Text = "Quyền (Privilege)";
            // 
            // ObjectPriDD
            // 
            this.ObjectPriDD.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ObjectPriDD.Enabled = false;
            this.ObjectPriDD.FormattingEnabled = true;
            this.ObjectPriDD.Location = new System.Drawing.Point(698, 441);
            this.ObjectPriDD.Name = "ObjectPriDD";
            this.ObjectPriDD.Size = new System.Drawing.Size(246, 24);
            this.ObjectPriDD.TabIndex = 44;
            // 
            // ObjectObjDD
            // 
            this.ObjectObjDD.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ObjectObjDD.Enabled = false;
            this.ObjectObjDD.FormattingEnabled = true;
            this.ObjectObjDD.Location = new System.Drawing.Point(698, 346);
            this.ObjectObjDD.Name = "ObjectObjDD";
            this.ObjectObjDD.Size = new System.Drawing.Size(246, 24);
            this.ObjectObjDD.TabIndex = 43;
            this.ObjectObjDD.SelectedIndexChanged += new System.EventHandler(this.ObjectObjDD_SelectedIndexChanged);
            // 
            // ObjectObjTxt
            // 
            this.ObjectObjTxt.Enabled = false;
            this.ObjectObjTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ObjectObjTxt.Location = new System.Drawing.Point(587, 344);
            this.ObjectObjTxt.Name = "ObjectObjTxt";
            this.ObjectObjTxt.Size = new System.Drawing.Size(105, 50);
            this.ObjectObjTxt.TabIndex = 42;
            this.ObjectObjTxt.Text = "Đối tượng";
            // 
            // ObjectUserDD
            // 
            this.ObjectUserDD.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ObjectUserDD.Enabled = false;
            this.ObjectUserDD.FormattingEnabled = true;
            this.ObjectUserDD.Location = new System.Drawing.Point(698, 247);
            this.ObjectUserDD.Name = "ObjectUserDD";
            this.ObjectUserDD.Size = new System.Drawing.Size(246, 24);
            this.ObjectUserDD.TabIndex = 41;
            this.ObjectUserDD.SelectedIndexChanged += new System.EventHandler(this.ObjectUserDD_SelectedIndexChanged);
            // 
            // ObjectUserPriTxt
            // 
            this.ObjectUserPriTxt.AutoSize = true;
            this.ObjectUserPriTxt.Enabled = false;
            this.ObjectUserPriTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ObjectUserPriTxt.Location = new System.Drawing.Point(587, 245);
            this.ObjectUserPriTxt.Name = "ObjectUserPriTxt";
            this.ObjectUserPriTxt.Size = new System.Drawing.Size(100, 22);
            this.ObjectUserPriTxt.TabIndex = 40;
            this.ObjectUserPriTxt.Text = "User / Role";
            // 
            // ObjectPriRadioLb
            // 
            this.ObjectPriRadioLb.AutoSize = true;
            this.ObjectPriRadioLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ObjectPriRadioLb.Location = new System.Drawing.Point(640, 146);
            this.ObjectPriRadioLb.Name = "ObjectPriRadioLb";
            this.ObjectPriRadioLb.Size = new System.Drawing.Size(204, 29);
            this.ObjectPriRadioLb.TabIndex = 39;
            this.ObjectPriRadioLb.Text = "Quyền đối tượng";
            // 
            // SystemPriDD
            // 
            this.SystemPriDD.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.SystemPriDD.Enabled = false;
            this.SystemPriDD.FormattingEnabled = true;
            this.SystemPriDD.Location = new System.Drawing.Point(312, 346);
            this.SystemPriDD.Name = "SystemPriDD";
            this.SystemPriDD.Size = new System.Drawing.Size(232, 24);
            this.SystemPriDD.TabIndex = 38;
            // 
            // SystemPriTxt
            // 
            this.SystemPriTxt.Enabled = false;
            this.SystemPriTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SystemPriTxt.Location = new System.Drawing.Point(201, 335);
            this.SystemPriTxt.Name = "SystemPriTxt";
            this.SystemPriTxt.Size = new System.Drawing.Size(105, 50);
            this.SystemPriTxt.TabIndex = 37;
            this.SystemPriTxt.Text = "Quyền (Privilege)";
            // 
            // SystemUserDD
            // 
            this.SystemUserDD.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.SystemUserDD.Enabled = false;
            this.SystemUserDD.FormattingEnabled = true;
            this.SystemUserDD.Location = new System.Drawing.Point(312, 247);
            this.SystemUserDD.Name = "SystemUserDD";
            this.SystemUserDD.Size = new System.Drawing.Size(232, 24);
            this.SystemUserDD.TabIndex = 36;
            this.SystemUserDD.SelectedIndexChanged += new System.EventHandler(this.SystemUserDD_SelectedIndexChanged);
            // 
            // SystemUserlbl
            // 
            this.SystemUserlbl.AutoSize = true;
            this.SystemUserlbl.Enabled = false;
            this.SystemUserlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SystemUserlbl.Location = new System.Drawing.Point(201, 245);
            this.SystemUserlbl.Name = "SystemUserlbl";
            this.SystemUserlbl.Size = new System.Drawing.Size(100, 22);
            this.SystemUserlbl.TabIndex = 35;
            this.SystemUserlbl.Text = "User / Role";
            // 
            // SystemPriRadioLb
            // 
            this.SystemPriRadioLb.AutoSize = true;
            this.SystemPriRadioLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SystemPriRadioLb.Location = new System.Drawing.Point(244, 146);
            this.SystemPriRadioLb.Name = "SystemPriRadioLb";
            this.SystemPriRadioLb.Size = new System.Drawing.Size(196, 29);
            this.SystemPriRadioLb.TabIndex = 34;
            this.SystemPriRadioLb.Text = "Quyền hệ thống";
            // 
            // ThuHoiQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ObjPriBtn);
            this.Controls.Add(this.SystemBtnPri);
            this.Controls.Add(this.ObjectPriTxt);
            this.Controls.Add(this.ObjectPriDD);
            this.Controls.Add(this.ObjectObjDD);
            this.Controls.Add(this.ObjectObjTxt);
            this.Controls.Add(this.ObjectUserDD);
            this.Controls.Add(this.ObjectUserPriTxt);
            this.Controls.Add(this.ObjectPriRadioLb);
            this.Controls.Add(this.SystemPriDD);
            this.Controls.Add(this.SystemPriTxt);
            this.Controls.Add(this.SystemUserDD);
            this.Controls.Add(this.SystemUserlbl);
            this.Controls.Add(this.SystemPriRadioLb);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ThuHoiQuyen";
            this.Size = new System.Drawing.Size(1137, 842);
            this.Load += new System.EventHandler(this.ThuHoiQuyen_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton ObjectPriRadio;
        private System.Windows.Forms.RadioButton SystemPriRadio;
        private System.Windows.Forms.Button ObjPriBtn;
        private System.Windows.Forms.Button SystemBtnPri;
        private System.Windows.Forms.Label ObjectPriTxt;
        private System.Windows.Forms.ComboBox ObjectPriDD;
        private System.Windows.Forms.ComboBox ObjectObjDD;
        private System.Windows.Forms.Label ObjectObjTxt;
        private System.Windows.Forms.ComboBox ObjectUserDD;
        private System.Windows.Forms.Label ObjectUserPriTxt;
        private System.Windows.Forms.Label ObjectPriRadioLb;
        private System.Windows.Forms.ComboBox SystemPriDD;
        private System.Windows.Forms.Label SystemPriTxt;
        private System.Windows.Forms.ComboBox SystemUserDD;
        private System.Windows.Forms.Label SystemUserlbl;
        private System.Windows.Forms.Label SystemPriRadioLb;
    }
}
