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

namespace QuanTriTrongOracle.TabGVU
{
    public partial class GVU_DangKy : UserControl
    {
        OracleConnection con;
        public GVU_DangKy()
        {
            InitializeComponent();
        }

        private void GVU_DangKy_Load(object sender, EventArgs e)
        {

        }

        private void loadDKBtn_Click(object sender, EventArgs e)
        {
            con = connect.getConnection();
            con.Open();
            try
            {
                string query = "SELECT * FROM ADMINQL.DANGKY";
                using (OracleCommand cmd = new OracleCommand(query, con))
                {
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        DKDataGrid.DataSource = dataTable;
                        foreach (DataGridViewColumn column in DKDataGrid.Columns)
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

        private void LoadPCDKBtn_Click(object sender, EventArgs e)
        {
            con = connect.getConnection();
            con.Open();
            try
            {
                string query = "SELECT * FROM ADMINQL.PHANCONG";
                using (OracleCommand cmd = new OracleCommand(query, con))
                {
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        PCDKDataGrid.DataSource = dataTable;
                        foreach (DataGridViewColumn column in PCDKDataGrid.Columns)
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

        private void InsertDKBtn_Click(object sender, EventArgs e)
        {
            string masv = MaSVDKInsTxt.Text;
            string magv = MaGVDKInsTxt.Text;
            string mahp = MaHPDKInsTxt.Text;
            int hk = int.Parse(HKDKInsTxt.Text);
            int nam = int.Parse(NamDKInsTxt.Text);
            string mact = MaCTDKInsTxt.Text;

            OracleConnection con = null;
            try
            {
                // Tạo kết nối
                con = connect.getConnection();
                con.Open();

                // Tạo và thực thi command
                using (OracleCommand cmd = new OracleCommand("ADMINQL.PROC_INSERT_DANGKY", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_MASV", OracleDbType.Varchar2).Value = masv;
                    cmd.Parameters.Add("p_MAGV", OracleDbType.Varchar2).Value = magv;
                    cmd.Parameters.Add("p_MAHP", OracleDbType.Varchar2).Value = mahp;
                    cmd.Parameters.Add("p_HK", OracleDbType.Int32).Value = hk;
                    cmd.Parameters.Add("p_NAM", OracleDbType.Decimal).Value = nam;
                    cmd.Parameters.Add("p_MACT", OracleDbType.Varchar2).Value = mact;

                    // Thực thi truy vấn
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Thêm đăng ký thành công.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm đăng ký: " + ex.Message);
            }
            finally
            {
                // Đảm bảo rằng kết nối sẽ được đóng ngay cả khi có ngoại lệ xảy ra
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void LoadDKDelBtn_Click(object sender, EventArgs e)
        {
            con = connect.getConnection();
            con.Open();
            try
            {
                string query = "SELECT * FROM ADMINQL.DANGKY";
                using (OracleCommand cmd = new OracleCommand(query, con))
                {
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        DKDelDataGrid.DataSource = dataTable;
                        foreach (DataGridViewColumn column in DKDelDataGrid.Columns)
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

        private void DeleteDKBtn_Click(object sender, EventArgs e)
        {
            string masv = MaSVDKDelTxt.Text;
            string magv = MaGVDKDelTxt.Text;
            string mahp = MaHPDKDelTxt.Text;
            int hk = int.Parse(HKDKDelTxt.Text);
            int nam = int.Parse(NamDKDelTxt.Text);
            string mact = MaCTDKDelTxt.Text;

            OracleConnection con = null;
            try
            {
                // Tạo kết nối
                con = connect.getConnection();
                con.Open();

                // Tạo và thực thi command
                using (OracleCommand cmd = new OracleCommand("ADMINQL.PROC_DELETE_DANGKY", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_MASV", OracleDbType.Varchar2).Value = masv;
                    cmd.Parameters.Add("p_MAGV", OracleDbType.Varchar2).Value = magv;
                    cmd.Parameters.Add("p_MAHP", OracleDbType.Varchar2).Value = mahp;
                    cmd.Parameters.Add("p_HK", OracleDbType.Int32).Value = hk;
                    cmd.Parameters.Add("p_NAM", OracleDbType.Decimal).Value = nam;
                    cmd.Parameters.Add("p_MACT", OracleDbType.Varchar2).Value = mact;

                    // Thực thi truy vấn
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Xóa đăng ký thành công.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa đăng ký: " + ex.Message);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void PCDKDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                MessageBox.Show("BẠN CHỌN DÒNG " + e.RowIndex.ToString());
                // Lấy dòng được chọn từ DataGridView
                DataGridViewRow row = PCDKDataGrid.Rows[e.RowIndex];
                MaGVDKInsTxt.Text = row.Cells["MAGV"].Value.ToString();
                MaHPDKInsTxt.Text = row.Cells["MAHP"].Value.ToString();
                HKDKInsTxt.Text = Convert.ToInt32(row.Cells["HK"].Value).ToString();
                NamDKInsTxt.Text = Convert.ToInt32(row.Cells["NAM"].Value).ToString();
                MaCTDKInsTxt.Text = row.Cells["MACT"].Value.ToString();
            }
        }

        private void DKDelDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                MessageBox.Show("BẠN CHỌN DÒNG " + e.RowIndex.ToString());
                // Lấy dòng được chọn từ DataGridView
                DataGridViewRow row = DKDelDataGrid.Rows[e.RowIndex];
                MaSVDKDelTxt.Text = row.Cells["MASV"].Value.ToString();
                MaGVDKDelTxt.Text = row.Cells["MAGV"].Value.ToString();
                MaHPDKDelTxt.Text = row.Cells["MAHP"].Value.ToString();
                HKDKDelTxt.Text = Convert.ToInt32(row.Cells["HK"].Value).ToString();
                NamDKDelTxt.Text = Convert.ToInt32(row.Cells["NAM"].Value).ToString();
                MaCTDKDelTxt.Text = row.Cells["MACT"].Value.ToString();
            }
        }
    }
}
