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
    public partial class GVU_KHMo : UserControl
    {
        OracleConnection con;
        private string oldMaHPKHMO;
        private int oldHKKHMO;
        private int oldNamKHMO;
        private string oldMACTKHMO;
        public GVU_KHMo()
        {
            InitializeComponent();
        }

        private void LoadKHMoBtn_Click(object sender, EventArgs e)
        {
            con = connect.getConnection();
            con.Open();
            try
            {
                string query = "SELECT * FROM ADMINQL.KHMO";
                using (OracleCommand cmd = new OracleCommand(query, con))
                {
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        KHMoDataGrid.DataSource = dataTable;
                        foreach (DataGridViewColumn column in KHMoDataGrid.Columns)
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

        private void InsertKHMoTxt_Click(object sender, EventArgs e)
        {
            string mahp = MaHPKHMoTxt.Text;
            int hk = int.Parse(HocKyTxt.Text);
            int nam = int.Parse(NamTxt.Text);
            string mact = MaCTKHMoTxt.Text;

            // Kiểm tra xem các trường thông tin đã được nhập đủ chưa
            if (mahp.Length == 0 || mact.Length == 0)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }
            if (nam <= 0 || hk <= 0)
            {
                MessageBox.Show("Vui lòng điền số lớn hơn 0.");
                return;
            }
            OracleConnection con = null;
            try
            {
                // Tạo kết nối
                con = connect.getConnection();
                con.Open();

                // Tạo và thực thi command
                using (OracleCommand cmd = new OracleCommand("ADMINQL.PROC_INSERT_KHMO", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm các tham số
                    cmd.Parameters.Add("p_MAHP", OracleDbType.Varchar2).Value = mahp;
                    cmd.Parameters.Add("p_HK", OracleDbType.Int32).Value = hk;
                    cmd.Parameters.Add("p_NAM", OracleDbType.Int32).Value = nam;
                    cmd.Parameters.Add("p_MACT", OracleDbType.Varchar2).Value = mact;

                    // Thực thi procedure PROC_INSERTHOCPHAN
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Thêm kế hoạch mở thành công.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm kế hoạch mở: " + ex.Message);
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

        private void LoadKHMoUpdBtn_Click(object sender, EventArgs e)
        {
            con = connect.getConnection();
            con.Open();
            try
            {
                string query = "SELECT * FROM ADMINQL.KHMO";
                using (OracleCommand cmd = new OracleCommand(query, con))
                {
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        KHMoUpdDataGrid.DataSource = dataTable;
                        foreach (DataGridViewColumn column in KHMoUpdDataGrid.Columns)
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

        private void UpdateKHMoBtn_Click(object sender, EventArgs e)
        {
            // Lấy các giá trị mới từ các textbox trên giao diện
            string mahpNew = MaHPKHMoUpdTxt.Text;
            int hkNew = int.Parse(HocKyUpdTxt.Text);
            int namNew = int.Parse(NamUpdTxt.Text);
            string mactNew = MaCTKHMoUpdTxt.Text;

            // Lấy các giá trị cũ đã lưu trước đó
            string mahpOld = oldMaHPKHMO;
            int hkOld = oldHKKHMO;
            int namOld = oldNamKHMO;
            string mactOld = oldMACTKHMO;

            OracleConnection con = null;
            try
            {
                // Tạo kết nối
                con = connect.getConnection();
                con.Open();

                // Tạo và thực thi command
                using (OracleCommand cmd = new OracleCommand("ADMINQL.PROC_UPDATE_KHMO", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm các tham số
                    cmd.Parameters.Add("p_MAHP_old", OracleDbType.Varchar2).Value = mahpOld;
                    cmd.Parameters.Add("p_HK_old", OracleDbType.Int32).Value = hkOld;
                    cmd.Parameters.Add("p_NAM_old", OracleDbType.Decimal).Value = namOld;
                    cmd.Parameters.Add("p_MACT_old", OracleDbType.Varchar2).Value = mactOld;
                    cmd.Parameters.Add("p_MAHP_new", OracleDbType.Varchar2).Value = mahpNew;
                    cmd.Parameters.Add("p_HK_new", OracleDbType.Int32).Value = hkNew;
                    cmd.Parameters.Add("p_NAM_new", OracleDbType.Decimal).Value = namNew;
                    cmd.Parameters.Add("p_MACT_new", OracleDbType.Varchar2).Value = mactNew;

                    // Thực thi truy vấn
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cập nhật thông tin học phần thành công.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật thông tin học phần: " + ex.Message);
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
    }
}
