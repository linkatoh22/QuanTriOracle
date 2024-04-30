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
    public partial class GVU_SinhVien : UserControl
    {
        OracleConnection con;
        public GVU_SinhVien()
        {
            InitializeComponent();
        }

        private void LoadSVBtn_Click(object sender, EventArgs e)
        {
            con = connect.getConnection();
            con.Open();
            try
            {
                string query = "SELECT * FROM ADMINQL.SINHVIEN";
                using (OracleCommand cmd = new OracleCommand(query, con))
                {
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        SVDataGrid.DataSource = dataTable;
                        foreach (DataGridViewColumn column in SVDataGrid.Columns)
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

        private void InsertSVBtn_Click(object sender, EventArgs e)
        {
            string mssv = MSSVtxt.Text;
            string name = NameTxt.Text;
            string gender = GetSelectedGender();
            string address = AddressTxt.Text;
            string birth = BirthTxt.Text;
            string phone = SDTTxt.Text;
            string ctdt = CTDTTxt.Text;
            string nganh = NganhTxt.Text;
            if (mssv.Length == 0 || name.Length == 0 || gender.Length == 0 || address.Length == 0 || phone.Length == 0 || ctdt.Length == 0 || nganh.Length == 0)
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
                command.CommandText = "ADMINQL.PROC_THEMSINHVIEN";
                command.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số cho stored procedure
                command.Parameters.Add("p_MSSV", OracleDbType.Varchar2).Value = mssv;
                command.Parameters.Add("p_HOTEN", OracleDbType.Varchar2).Value = name;
                command.Parameters.Add("p_PHAI", OracleDbType.Varchar2).Value = gender;
                command.Parameters.Add("p_NGSINH", OracleDbType.Varchar2).Value = birth; // Đảm bảo cung cấp giá trị ngày sinh (dob) ở đây
                command.Parameters.Add("p_DIACHI", OracleDbType.Varchar2).Value = address;
                command.Parameters.Add("p_DIENTHOAI", OracleDbType.Varchar2).Value = phone;
                command.Parameters.Add("p_MACT", OracleDbType.Varchar2).Value = ctdt;
                command.Parameters.Add("p_MANGANH", OracleDbType.Varchar2).Value = nganh;

                command.ExecuteNonQuery();

                MessageBox.Show("THÊM SINH VIÊN THÀNH CÔNG");
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
        private string GetSelectedGender()
        {
            if (MaleRadio.Checked)
            {
                return "Nam";
            }
            else if (FMaleRadio.Checked)
            {
                return "Nu";
            }
            return "";
        }

        private void LoadSVUpdBtn_Click(object sender, EventArgs e)
        {
            string mssvTxt = mssvUpdTxt.Text;
            if (mssvTxt.Length == 0)
            {
                MessageBox.Show("VUI LÒNG NHẬP MSSV");
                return;
            }

            OracleConnection con = null;
            try
            {
                con = connect.getConnection();
                con.Open();

                string query = "SELECT * FROM ADMINQL.SINHVIEN WHERE MASV = :mssv";
                using (OracleCommand cmd = new OracleCommand(query, con))
                {
                    cmd.Parameters.Add("mssv", OracleDbType.Varchar2).Value = mssvTxt;

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Lấy dữ liệu từ OracleDataReader và gán vào các TextBox
                            mssvUpdTxt.Text = reader.GetString(reader.GetOrdinal("MASV"));
                            NameUpdTxt.Text = reader.GetString(reader.GetOrdinal("HOTEN"));
                            string gender = reader.GetString(reader.GetOrdinal("PHAI"));
                            if (gender == "Nam")
                            {
                                MaleUpdRad.Checked = true;
                            }
                            else { FMaleUpdRad.Checked = true; }
                            BirthUpdTxt.Text = reader.GetDateTime(reader.GetOrdinal("NGSINH")).ToString("yyyy-MM-dd");
                            AddressUpdTxt.Text = reader.GetString(reader.GetOrdinal("DIACHI"));
                            PhoneUpdTxt.Text = reader.GetString(reader.GetOrdinal("DIENTHOAI"));
                            CTDTUpdTxt.Text = reader.GetString(reader.GetOrdinal("MACT"));
                            NganhUpdTxt.Text = reader.GetString(reader.GetOrdinal("MANGANH"));
                            TCTLUpdTxt.Text = reader.GetInt32(reader.GetOrdinal("SOTCTL")).ToString();
                            DTBTLUpdTxt.Text = reader.GetDecimal(reader.GetOrdinal("DTBTL")).ToString();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sinh viên có MSSV này");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin sinh viên: " + ex.Message);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void UpdateSVBtn_Click(object sender, EventArgs e)
        {
            string mssv = mssvUpdTxt.Text;
            string name = NameUpdTxt.Text;
            string birth = BirthUpdTxt.Text;
            string gender = "Nu";
            if (MaleUpdRad.Checked)
            {
                gender = "Nam";
            }
            string address = AddressUpdTxt.Text;
            string phone = PhoneUpdTxt.Text;
            string ctdt = CTDTUpdTxt.Text;
            string nganh = NganhUpdTxt.Text;
            string tctl = TCTLUpdTxt.Text;
            string dtb = DTBTLUpdTxt.Text;

            // Kiểm tra xem các trường thông tin đã được nhập đủ chưa
            if (mssv.Length == 0 || birth.Length == 0 || address.Length == 0 || phone.Length == 0 ||
                ctdt.Length == 0 || nganh.Length == 0 || tctl.Length == 0 || dtb.Length == 0 ||
                gender.Length == 0 || name.Length == 0)
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
                using (OracleCommand cmd = new OracleCommand("ADMINQL.PROC_UPDATE_STUDENT", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm các tham số
                    cmd.Parameters.Add("p_MSSV", OracleDbType.Varchar2).Value = mssv;
                    cmd.Parameters.Add("p_TEN", OracleDbType.Varchar2).Value = name;
                    cmd.Parameters.Add("p_NGSINH", OracleDbType.Date).Value = DateTime.Parse(birth);
                    cmd.Parameters.Add("p_DIACHI", OracleDbType.Varchar2).Value = address;
                    cmd.Parameters.Add("p_DIENTHOAI", OracleDbType.Varchar2).Value = phone;
                    cmd.Parameters.Add("p_PHAI", OracleDbType.Varchar2).Value = gender;
                    cmd.Parameters.Add("p_MACT", OracleDbType.Varchar2).Value = ctdt;
                    cmd.Parameters.Add("p_MANGANH", OracleDbType.Varchar2).Value = nganh;
                    cmd.Parameters.Add("p_SOTCTL", OracleDbType.Int32).Value = int.Parse(tctl);
                    cmd.Parameters.Add("p_DTBTL", OracleDbType.Decimal).Value = decimal.Parse(dtb);

                    // Thực thi truy vấn UPDATE
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cập nhật thông tin sinh viên thành công.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật thông tin sinh viên: " + ex.Message);
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
