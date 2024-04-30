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
    public partial class GVU_HocPhan : UserControl
    {
        OracleConnection con;
        public GVU_HocPhan()
        {
            InitializeComponent();
        }

        private void LoadHPBtn_Click(object sender, EventArgs e)
        {
            con = connect.getConnection();
            con.Open();
            try
            {
                string query = "SELECT * FROM ADMINQL.HOCPHAN";
                using (OracleCommand cmd = new OracleCommand(query, con))
                {
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        HPDataGrid.DataSource = dataTable;
                        foreach (DataGridViewColumn column in HPDataGrid.Columns)
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

        private void InsertHPBtn_Click(object sender, EventArgs e)
        {
            string maHP = MaHPTxt.Text;
            string tenHP = TenHPTxt.Text;
            int soTC = int.Parse(SoTCTxt.Text);
            int stLT = int.Parse(SoTietLTTxt.Text);
            int stTH = int.Parse(SoTietTHTxt.Text);
            int soSVTD = int.Parse(SVTDTxt.Text);
            string maDV = MaDVHPTxt.Text;

            // Kiểm tra xem các trường thông tin đã được nhập đủ chưa
            if (maHP.Length == 0 || tenHP.Length == 0 || maDV.Length == 0)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }
            if (soTC <= 0 || stLT <= 0 || stTH <= 0)
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
                using (OracleCommand cmd = new OracleCommand("ADMINQL.PROC_INSERTHOCPHAN", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm các tham số
                    cmd.Parameters.Add("p_MAHP", OracleDbType.Varchar2).Value = maHP;
                    cmd.Parameters.Add("p_TENHP", OracleDbType.NVarchar2).Value = tenHP;
                    cmd.Parameters.Add("p_SOTC", OracleDbType.Int32).Value = soTC;
                    cmd.Parameters.Add("p_STLT", OracleDbType.Int32).Value = stLT;
                    cmd.Parameters.Add("p_STTH", OracleDbType.Int32).Value = stTH;
                    cmd.Parameters.Add("p_SOSVTD", OracleDbType.Int32).Value = soSVTD;
                    cmd.Parameters.Add("p_MADV", OracleDbType.Varchar2).Value = maDV;

                    // Thực thi procedure PROC_INSERTHOCPHAN
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Thêm học phần thành công.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm học phần: " + ex.Message);
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

        private void UpdateHPBtn_Click(object sender, EventArgs e)
        {
            string mahp = MaHPUpdTxt.Text;
            string tenhp = TenHPUpdTxt.Text;
            int sotc = int.Parse(SoTCUpdTxt.Text);
            int svtd = int.Parse(SoSVTDUpdTxt.Text);
            string madv = MaDVHPUPdTxt.Text;
            int stth = int.Parse(SoTietTHUpdTxt.Text);
            int stlt = int.Parse(SoTietLTUpdTxt.Text);

            // Kiểm tra xem các trường thông tin đã được nhập đủ chưa
            if (mahp.Length == 0 || tenhp.Length == 0 || madv.Length == 0)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }
            if (sotc <= 0 || stlt <= 0 || stth <= 0)
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
                using (OracleCommand cmd = new OracleCommand("ADMINQL.PROC_UPDATEHOCPHAN", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm các tham số
                    cmd.Parameters.Add("p_MAHP", OracleDbType.Varchar2).Value = mahp;
                    cmd.Parameters.Add("p_TENHP", OracleDbType.NVarchar2).Value = tenhp;
                    cmd.Parameters.Add("p_SOTC", OracleDbType.Int32).Value = sotc;
                    cmd.Parameters.Add("p_STLT", OracleDbType.Int32).Value = stlt;
                    cmd.Parameters.Add("p_STTH", OracleDbType.Int32).Value = stth;
                    cmd.Parameters.Add("p_SOSVTD", OracleDbType.Int32).Value = svtd;
                    cmd.Parameters.Add("p_MADV", OracleDbType.Varchar2).Value = madv;

                    // Thực thi stored procedure
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
