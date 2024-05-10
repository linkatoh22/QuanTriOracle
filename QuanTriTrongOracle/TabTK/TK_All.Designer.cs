namespace QuanTriTrongOracle.TabTK
{
    partial class TK_All
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
            this.TableDataGrid = new System.Windows.Forms.DataGridView();
            this.LoadTableBtn = new System.Windows.Forms.Button();
            this.label37 = new System.Windows.Forms.Label();
            this.TableNameCB = new System.Windows.Forms.ComboBox();
            this.label36 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TableDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // TableDataGrid
            // 
            this.TableDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TableDataGrid.Location = new System.Drawing.Point(27, 118);
            this.TableDataGrid.Name = "TableDataGrid";
            this.TableDataGrid.RowHeadersWidth = 51;
            this.TableDataGrid.RowTemplate.Height = 24;
            this.TableDataGrid.Size = new System.Drawing.Size(896, 306);
            this.TableDataGrid.TabIndex = 102;
            // 
            // LoadTableBtn
            // 
            this.LoadTableBtn.Location = new System.Drawing.Point(265, 65);
            this.LoadTableBtn.Name = "LoadTableBtn";
            this.LoadTableBtn.Size = new System.Drawing.Size(75, 23);
            this.LoadTableBtn.TabIndex = 101;
            this.LoadTableBtn.Text = "Load data";
            this.LoadTableBtn.UseVisualStyleBackColor = true;
            this.LoadTableBtn.Click += new System.EventHandler(this.LoadTableBtn_Click);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(45, 68);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(68, 16);
            this.label37.TabIndex = 100;
            this.label37.Text = "Tên bảng:";
            // 
            // TableNameCB
            // 
            this.TableNameCB.FormattingEnabled = true;
            this.TableNameCB.Location = new System.Drawing.Point(119, 65);
            this.TableNameCB.Name = "TableNameCB";
            this.TableNameCB.Size = new System.Drawing.Size(121, 24);
            this.TableNameCB.TabIndex = 99;
            this.TableNameCB.SelectedIndexChanged += new System.EventHandler(this.TableNameCB_SelectedIndexChanged);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(22, 23);
            this.label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(264, 25);
            this.label36.TabIndex = 98;
            this.label36.Text = "Chọn bảng để xem dữ liệu";
            // 
            // TK_All
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.TableDataGrid);
            this.Controls.Add(this.LoadTableBtn);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.TableNameCB);
            this.Controls.Add(this.label36);
            this.Name = "TK_All";
            this.Size = new System.Drawing.Size(956, 494);
            ((System.ComponentModel.ISupportInitialize)(this.TableDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView TableDataGrid;
        private System.Windows.Forms.Button LoadTableBtn;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.ComboBox TableNameCB;
        private System.Windows.Forms.Label label36;
    }
}
