﻿using System;
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
    public partial class XemUser : UserControl
    {
        OracleConnection con;

        public XemUser()
        {
            InitializeComponent();
            // Khởi tạo kết nối Oracle
            con = connect.getConnection();
            // Mở kết nối
            con.Open();
            // Load dữ liệu từ Oracle vào DataGridView
            LoadData();
            // Thiết lập auto size cho các cột trong DataGridView
            SetupDataGridViewColumns();
            // Đóng kết nối sau khi đã sử dụng xong
            con.Close();
        }

        private void LoadData()
        {
            try
            {
                // Chuỗi truy vấn SELECT
                string query = "SELECT USERNAME,PASSWORD, CREATED, ACCOUNT_STATUS, EXPIRY_DATE, LAST_LOGIN FROM dba_users";

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

        // Fill content bằng khung chứa nó
        private void SetupDataGridViewColumns()
        {
            // Thiết lập AutoSizeColumnsMode của DataGridView là Fill
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Thiết lập AutoSizeMode của từng cột là Fill
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
