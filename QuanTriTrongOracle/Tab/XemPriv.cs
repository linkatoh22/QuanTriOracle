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


namespace QuanTriTrongOracle.Tab
{
    public partial class XemPriv : UserControl
    {
        OracleConnection con;

        public XemPriv()
        {
            InitializeComponent();
            // Khởi tạo kết nối Oracle
            con = connect.getConnection();
            // Khởi tạo kết nối Oracle
            con = connect.getConnection();
            // Mở kết nối
            con.Open();
            // Load dữ liệu từ Oracle vào DataGridView
            LoadData();
            // Đóng kết nối sau khi đã sử dụng xong
            con.Close();
        }

        private void LoadData()
        {
            try
            {
                // Chuỗi truy vấn SELECT
                string query = @"SELECT TP.GRANTEE, TP.TABLE_NAME, CP.PRIVILEGE, CP.COLUMN_NAME 
                                FROM DBA_TAB_PRIVS TP JOIN DBA_COL_PRIVS CP
                                ON TP.OWNER = CP.OWNER AND TP.TABLE_NAME = CP.TABLE_NAME
                                WHERE CP.PRIVILEGE IN('SELECT', 'INSERT', 'UPDATE', 'DELETE')";

                // Tạo một OracleCommand để thực thi truy vấn
                using (OracleCommand cmd = new OracleCommand(query, con))
                {
                    // Tạo một OracleDataAdapter để nạp dữ liệu từ truy vấn vào DataTable
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        // Tạo một DataTable để lưu trữ dữ liệu
                        DataTable dataTable = new DataTable();
                        // Nạp dữ liệu từ truy vấn vào DataTable
                        adapter.Fill(dataTable);
                        // Đặt DataTable làm nguồn dữ liệu cho DataGridView
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
