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
    public partial class TK_NhanSu : UserControl
    {
        OracleConnection con;
        public TK_NhanSu()
        {
            InitializeComponent();
        }

        private void LoadNSBtn_Click(object sender, EventArgs e)
        {
            con = connect.getConnection();
            con.Open();
            try
            {
                string query = "SELECT * FROM ADMINQL.NHANSU";
                using (OracleCommand cmd = new OracleCommand(query, con))
                {
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        NSDataGrid.DataSource = dataTable;
                        foreach (DataGridViewColumn column in NSDataGrid.Columns)
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

        private void InsertNSBtn_Click(object sender, EventArgs e)
        {
            string ngaysinh = BirthNSTxt.Text;

            // Lấy các giá trị khác từ các control trên giao diện
            string manv = MaNVtxt.Text;
            string hoten = HoTenNSTxt.Text;
            string phai = "Nu";
            if (MaleRadio.Checked) { phai = "Nam"; }
            double phucap = double.Parse(PhuCapNSTxt.Text); // Sử dụng kiểu dữ liệu Double thay cho float
            string dienthoai = SDTTxt.Text;
            string vaitro = VaitroTxt.Text;
            string madv = MaDVTxt.Text;

            OracleConnection con = null;
            try
            {
                // Tạo kết nối
                con = connect.getConnection();
                con.Open();

                // Tạo và thực thi command
                using (OracleCommand cmd = new OracleCommand("ADMINQL.PROC_INSERT_NHANSU", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm các tham số
                    cmd.Parameters.Add("p_MANV", OracleDbType.Varchar2).Value = manv;
                    cmd.Parameters.Add("p_HOTEN", OracleDbType.NVarchar2).Value = hoten;
                    cmd.Parameters.Add("p_PHAI", OracleDbType.NVarchar2).Value = phai;
                    cmd.Parameters.Add("p_NGSINH", OracleDbType.Varchar2).Value = ngaysinh;
                    cmd.Parameters.Add("p_PHUCAP", OracleDbType.Double).Value = phucap; // Sử dụng kiểu dữ liệu Double
                    cmd.Parameters.Add("p_DIENTHOAI", OracleDbType.Char).Value = dienthoai;
                    cmd.Parameters.Add("p_VAITRO", OracleDbType.NVarchar2).Value = vaitro;
                    cmd.Parameters.Add("p_MADV", OracleDbType.Varchar2).Value = madv;

                    // Thực thi truy vấn
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Thêm nhân sự thành công.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhân sự: " + ex.Message);
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

        private void LoadSVUpdBtn_Click(object sender, EventArgs e)
        {
            string manv = manvUpdTxt.Text;
            if (manv.Length == 0)
            {
                MessageBox.Show("VUI LÒNG NHẬP MSSV");
                return;
            }

            OracleConnection con = null;
            try
            {
                con = connect.getConnection();
                con.Open();

                string query = "SELECT * FROM ADMINQL.NHANSU WHERE MANV = :manv";
                using (OracleCommand cmd = new OracleCommand(query, con))
                {
                    cmd.Parameters.Add("manv", OracleDbType.Varchar2).Value = manv;

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Lấy dữ liệu từ OracleDataReader và gán vào các TextBox
                            manvUpdTxt.Text = reader.GetString(reader.GetOrdinal("MANV"));
                            NameUpdTxt.Text = reader.GetString(reader.GetOrdinal("HOTEN"));
                            string gender = reader.GetString(reader.GetOrdinal("PHAI"));
                            if (gender == "Nam")
                            {
                                MaleUpdRad.Checked = true;
                            }
                            else { FMaleUpdRad.Checked = true; }
                            BirthUpdTxt.Text = reader.GetDateTime(reader.GetOrdinal("NGSINH")).ToString("yyyy-MM-dd");
                            PhuCapUpdTxt.Text = reader.GetString(reader.GetOrdinal("PHUCAP"));
                            PhoneUpdTxt.Text = reader.GetString(reader.GetOrdinal("DIENTHOAI"));
                            VaiTroUpdTxt.Text = reader.GetString(reader.GetOrdinal("VAITRO"));
                            MaDVUpdTxt.Text = reader.GetString(reader.GetOrdinal("MADV"));
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy nhân sự có mã NV này");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin nhân sự: " + ex.Message);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void UpdateNSBtn_Click(object sender, EventArgs e)
        {
            string manv = MaNVtxt.Text;
            string hoten = HoTenNSTxt.Text;
            string phai = "Nam";
            if (FMaleUpdRad.Checked) { phai = "Nu"; }
            string ngaySinhStr = BirthUpdTxt.Text;
            float phucap = float.Parse(PhuCapUpdTxt.Text);
            string dienthoai = PhoneUpdTxt.Text;
            string vaitro = VaiTroUpdTxt.Text;
            string madv = MaDVUpdTxt.Text;

            OracleConnection con = null;
            try
            {
                // Tạo kết nối
                con = connect.getConnection();
                con.Open();

                // Tạo và thực thi command
                using (OracleCommand cmd = new OracleCommand("ADMINQL.PROC_UPDATE_NHANSU", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm các tham số
                    cmd.Parameters.Add("p_MANV", OracleDbType.Varchar2).Value = manv;
                    cmd.Parameters.Add("p_HOTEN", OracleDbType.NVarchar2).Value = hoten;
                    cmd.Parameters.Add("p_PHAI", OracleDbType.NVarchar2).Value = phai;
                    cmd.Parameters.Add("p_NGSINH", OracleDbType.NVarchar2).Value = ngaySinhStr; // Sử dụng chuỗi ngày sinh
                    cmd.Parameters.Add("p_PHUCAP", OracleDbType.Decimal).Value = phucap;
                    cmd.Parameters.Add("p_DIENTHOAI", OracleDbType.Char).Value = dienthoai;
                    cmd.Parameters.Add("p_VAITRO", OracleDbType.NVarchar2).Value = vaitro;
                    cmd.Parameters.Add("p_MADV", OracleDbType.Varchar2).Value = madv;

                    // Thực thi truy vấn
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cập nhật thông tin nhân sự thành công.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật thông tin nhân sự: " + ex.Message);
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

        private void delNSBtn_Click(object sender, EventArgs e)
        {
            string manv = MaNVDelTxt.Text;

            OracleConnection con = null;
            try
            {
                // Tạo kết nối
                con = connect.getConnection();
                con.Open();

                // Tạo command SQL
                string sql = "DELETE FROM ADMINQL.NHANSU WHERE MANV = :manv";

                // Tạo command và thêm tham số
                using (OracleCommand cmd = new OracleCommand(sql, con))
                {
                    cmd.Parameters.Add("manv", OracleDbType.Varchar2).Value = manv;

                    // Thực thi truy vấn
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa nhân sự thành công.");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhân sự có mã nhân viên: " + manv);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa nhân sự: " + ex.Message);
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

        private void TK_NhanSu_Load(object sender, EventArgs e)
        {

        }
    }
}
