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
    public partial class GVU_PhanCong : UserControl
    {
        OracleConnection con;
        private string oldMaGVPC;
        private string oldMaHPPC;
        private int oldHKPC;
        private int oldNamPC;
        private string oldMaCTPC;
        public GVU_PhanCong()
        {
            InitializeComponent();
        }

        private void LoadPCBtn_Click(object sender, EventArgs e)
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
                        PCDataGrid.DataSource = dataTable;
                        foreach (DataGridViewColumn column in PCDataGrid.Columns)
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

        private void LoadPCUpdBtn_Click(object sender, EventArgs e)
        {
            con = connect.getConnection();
            con.Open();
            try
            {
                string query = @"SELECT * FROM ADMINQL.PHANCONG WHERE 
                                 MAHP IN (SELECT MAHP FROM ADMINQL.HOCPHAN WHERE MADV = 'VPK')";
                using (OracleCommand cmd = new OracleCommand(query, con))
                {
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        PCUpdDataGrid.DataSource = dataTable;
                        foreach (DataGridViewColumn column in PCUpdDataGrid.Columns)
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

        private void UpdatePCBtn_Click(object sender, EventArgs e)
        {
            // Lấy các giá trị mới từ các textbox trên giao diện
            string magvnew = MaGVPCUpdTxt.Text;
            string mahpNew = MaHPPCUpdTxt.Text;
            int hkNew = int.Parse(HKPCUpdTxt.Text);
            int namNew = int.Parse(NamPCUpdTxt.Text);
            string mactNew = MaCTPCUpdTxt.Text;

            // Lấy các giá trị cũ đã lưu trước đó
            string magvOld = oldMaGVPC;
            string mahpOld = oldMaHPPC;
            int hkOld = oldHKPC;
            int namOld = oldNamPC;
            string mactOld = oldMaCTPC;

            OracleConnection con = null;
            try
            {
                // Tạo kết nối
                con = connect.getConnection();
                con.Open();

                // Tạo và thực thi command
                using (OracleCommand cmd = new OracleCommand("ADMINQL.PROC_UPDATE_PHANCONG", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm các tham số
                    cmd.Parameters.Add("p_MAGV_old", OracleDbType.Varchar2).Value = magvOld;
                    cmd.Parameters.Add("p_MAHP_old", OracleDbType.Varchar2).Value = mahpOld;
                    cmd.Parameters.Add("p_HK_old", OracleDbType.Int32).Value = hkOld;
                    cmd.Parameters.Add("p_NAM_old", OracleDbType.Decimal).Value = namOld;
                    cmd.Parameters.Add("p_MACT_old", OracleDbType.Varchar2).Value = mactOld;
                    cmd.Parameters.Add("p_MAGV_new", OracleDbType.Varchar2).Value = magvnew;
                    cmd.Parameters.Add("p_MAHP_new", OracleDbType.Varchar2).Value = mahpNew;
                    cmd.Parameters.Add("p_HK_new", OracleDbType.Int32).Value = hkNew;
                    cmd.Parameters.Add("p_NAM_new", OracleDbType.Decimal).Value = namNew;
                    cmd.Parameters.Add("p_MACT_new", OracleDbType.Varchar2).Value = mactNew;

                    // Thực thi truy vấn
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cập nhật thông tin phân công thành công.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật thông tin phân công: " + ex.Message);
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

        private void PCUpdDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                MessageBox.Show("BẠN CHỌN DÒNG " + e.RowIndex.ToString());
                // Lấy dòng được chọn từ DataGridView
                DataGridViewRow row = PCUpdDataGrid.Rows[e.RowIndex];
                oldMaGVPC = row.Cells["MAGV"].Value.ToString();
                oldMaHPPC = row.Cells["MAHP"].Value.ToString();
                oldHKPC = Convert.ToInt32(row.Cells["HK"].Value);
                oldNamPC = Convert.ToInt32(row.Cells["NAM"].Value);
                oldMaCTPC = row.Cells["MACT"].Value.ToString();

                MaGVPCUpdTxt.Text = oldMaGVPC;
                MaHPPCUpdTxt.Text = oldMaHPPC;
                HKPCUpdTxt.Text = oldHKPC.ToString();
                NamPCUpdTxt.Text = oldNamPC.ToString();
                MaCTPCUpdTxt.Text = oldMaCTPC;
            }
        }
    }
}
