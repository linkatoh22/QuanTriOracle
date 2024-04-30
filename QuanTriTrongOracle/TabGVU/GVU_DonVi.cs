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
    public partial class GVU_DonVi : UserControl
    {
        OracleConnection con;
        public GVU_DonVi()
        {
            InitializeComponent();
        }

        private void loadDVBtn_Click(object sender, EventArgs e)
        {
            con = connect.getConnection();
            con.Open();
            try
            {
                string query = "SELECT * FROM ADMINQL.DONVI";
                using (OracleCommand cmd = new OracleCommand(query, con))
                {
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        DVDataGrid.DataSource = dataTable;
                        foreach (DataGridViewColumn column in DVDataGrid.Columns)
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

        private void InsertDVBtn_Click(object sender, EventArgs e)
        {
            string madv = MaDVTxt.Text;
            string tendv = TenDVTxt.Text;
            string coso = CoSoTxt.Text;
            if (madv.Length == 0 || tendv.Length == 0)
            {
                MessageBox.Show("CHƯA NHẬP ĐẦY ĐỦ DỮ LIỆU");
                return;
            }
            OracleConnection con = null;
            try
            {
                con = connect.getConnection();
                con.Open();

                OracleCommand command = con.CreateCommand();
                command.CommandText = "ADMINQL.PROC_THEMDONVI";
                command.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số cho stored procedure
                command.Parameters.Add("p_MADV", OracleDbType.Varchar2).Value = madv;
                command.Parameters.Add("p_TENDV", OracleDbType.Varchar2).Value = tendv;
                command.Parameters.Add("p_COSO", OracleDbType.Varchar2).Value = coso;

                command.ExecuteNonQuery();

                MessageBox.Show("THÊM DƠN VỊ THÀNH CÔNG");
            }
            catch (Exception ex)
            {
                MessageBox.Show("LỖI: " + ex.Message);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void LoadDVUpdBtn_Click(object sender, EventArgs e)
        {
            string madv = MaDVUpTxt.Text;
            if (madv.Length == 0)
            {
                MessageBox.Show("VUI LÒNG NHẬP MÃ ĐƠN VỊ");
                return;
            }

            OracleConnection con = null;
            try
            {
                con = connect.getConnection();
                con.Open();

                string query = "SELECT * FROM ADMINQL.DONVI WHERE MADV = :madv";
                using (OracleCommand cmd = new OracleCommand(query, con))
                {
                    cmd.Parameters.Add("madv", OracleDbType.Varchar2).Value = madv;

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Lấy dữ liệu từ OracleDataReader và gán vào các TextBox
                            TenDVUpdTxt.Text = reader.GetString(reader.GetOrdinal("TENDV"));
                            CoSoUpdTxt.Text = reader.GetString(reader.GetOrdinal("COSO"));
                            TrgDVUpdTxt.Text = reader.GetString(reader.GetOrdinal("TRGDV"));
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy đơn vị có MADV này");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin đơn vị: " + ex.Message);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void UpdateDVBtn_Click(object sender, EventArgs e)
        {
            string madv = MaDVUpTxt.Text;
            string tendv = TenDVUpdTxt.Text;
            string coso = CoSoUpdTxt.Text;
            // Kiểm tra xem các trường thông tin đã được nhập đủ chưa
            if (madv.Length == 0 || tendv.Length == 0)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }

            OracleConnection con = null;
            try
            {
                // Tạo kết nối
                con = connect.getConnection();
                con.Open();

                // Tạo và thực thi command
                using (OracleCommand cmd = new OracleCommand("ADMINQL.PROC_UPDATEDONVI", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm các tham số
                    cmd.Parameters.Add("p_MADV", OracleDbType.Varchar2).Value = madv;
                    cmd.Parameters.Add("p_TENDV", OracleDbType.Varchar2).Value = tendv;
                    cmd.Parameters.Add("p_COSO", OracleDbType.Varchar2).Value = coso;

                    // Thực thi truy vấn UPDATE
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cập nhật thông tin đơn vị thành công.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật thông tin đơn vị: " + ex.Message);
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
