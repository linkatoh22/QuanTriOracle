using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace QuanTriTrongOracle.TabTK
{
    public partial class TK_All : UserControl
    {
        OracleConnection con;
        public TK_All()
        {
            InitializeComponent();
        }

        private void LoadTableBtn_Click(object sender, EventArgs e)
        {
            // Thêm các mục vào ComboBox
            TableNameCB.Items.Clear();
            TableNameCB.Items.Add("NHANSU");
            TableNameCB.Items.Add("SINHVIEN");
            TableNameCB.Items.Add("DONVI");
            TableNameCB.Items.Add("HOCPHAN");
            TableNameCB.Items.Add("KHMO");
            TableNameCB.Items.Add("PHANCONG");
            TableNameCB.Items.Add("DANGKY");

            // Chọn mục mặc định (nếu cần)
            TableNameCB.SelectedIndex = 0; // Chọn mục đầu tiên
        }
        private void TableNameCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy tên bảng từ ComboBox
            string selectedTableName = TableNameCB.SelectedItem.ToString();

            con = connect.getConnection();
            con.Open();
            try
            {
                string query = "SELECT * FROM ADMINQL." + selectedTableName;

                using (OracleCommand cmd = new OracleCommand(query, con))
                {
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        TableDataGrid.DataSource = dataTable;
                        foreach (DataGridViewColumn column in TableDataGrid.Columns)
                        {
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                MessageBox.Show("Error: " + ex.Message);
            }
            con.Close();
        }
    }
}
