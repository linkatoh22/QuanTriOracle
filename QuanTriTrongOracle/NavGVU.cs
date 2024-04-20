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

namespace QuanTriTrongOracle
{
    public partial class NavGVU : Form
    {
        OracleConnection con;
        //KHMO, biến để lưu các giá trị cũ để có thể cập nhật dễ dàng hơn
        private string oldMaHPKHMO;
        private int oldHKKHMO;
        private int oldNamKHMO;
        private string oldMACTKHMO;
        //PHANCONG, biến để lưu các giá trị cũ để có thể cập nhật dễ dàng hơn
        private string oldMaGVPC;
        private string oldMaHPPC;
        private int oldHKPC;
        private int oldNamPC;
        private string oldMaCTPC;
        public NavGVU()
        {
            InitializeComponent();
        }
        //TAB1
        private void UpdateNSBtn_Click(object sender, EventArgs e)
        {
            string phone = SDTUpdTxt.Text;
            if (phone.Length != 10)
            {
                MessageBox.Show("SĐT PHẢI BẰNG 10 CHỮ SỐ");
                return;
            }

            OracleConnection con = null;
            try
            {
                con = connect.getConnection();
                con.Open();

                OracleCommand command = con.CreateCommand();
                command.CommandText = "ADMINQL.PROC_UPD_SDT";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("phone", OracleDbType.Varchar2).Value = phone;

                command.ExecuteNonQuery();

                MessageBox.Show("CẬP NHẬT SĐT THÀNH CÔNG");
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



        private void LoadNSBtn_Click(object sender, EventArgs e)
        {
            con = connect.getConnection();
            con.Open();
            try
            {
                string query = "SELECT * FROM ADMINQL.NHANSU WHERE MANV = SYS_CONTEXT('USERENV','SESSION_USER')";
                using (OracleCommand cmd = new OracleCommand(query, con))
                {
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        ProfileDataGrid.DataSource = dataTable;
                        foreach (DataGridViewColumn column in ProfileDataGrid.Columns)
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
        //TAB2

        //TAB3
        //TAB4
        //TAB5
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ProfileNS_Click(object sender, EventArgs e)
        {

        }


        private void ProfileDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

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


        private void NavGVU_Load(object sender, EventArgs e)
        {

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
                            if(gender == "Nam")
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

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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

        private void label31_Click(object sender, EventArgs e)
        {

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

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void UpdateDVBtn_Click(object sender, EventArgs e)
        {
            string madv = MaDVUpTxt.Text;
            string tendv = TenDVUpdTxt.Text;
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

        private void label27_Click(object sender, EventArgs e)
        {

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

        private void tabPage3_Click(object sender, EventArgs e)
        {

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


        private void LoadHPUpdBtn_Click(object sender, EventArgs e)
        {
            string mahp = MaHPUpdTxt.Text;
            if (mahp.Length == 0)
            {
                MessageBox.Show("VUI LÒNG NHẬP MÃ HỌC PHẦN");
                return;
            }

            OracleConnection con = null;
            try
            {
                con = connect.getConnection();
                con.Open();

                string query = "SELECT * FROM ADMINQL.HOCPHAN WHERE MAHP = :mahp";
                using (OracleCommand cmd = new OracleCommand(query, con))
                {
                    cmd.Parameters.Add("mahp", OracleDbType.Varchar2).Value = mahp;

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Lấy dữ liệu từ OracleDataReader và gán vào các TextBox
                            MaHPUpdTxt.Text = reader.GetString(reader.GetOrdinal("MAHP"));
                            TenHPUpdTxt.Text = reader.GetString(reader.GetOrdinal("TENHP"));
                            SoTCUpdTxt.Text = reader.GetString(reader.GetOrdinal("SOTC"));
                            SoSVTDUpdTxt.Text = reader.GetString(reader.GetOrdinal("SOSVTD"));
                            MaDVHPUPdTxt.Text = reader.GetString(reader.GetOrdinal("MADV"));
                            SoTietTHUpdTxt.Text = reader.GetString(reader.GetOrdinal("STTH"));
                            SoTietLTUpdTxt.Text = reader.GetString(reader.GetOrdinal("STLT"));
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy học phần có MAHP này");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin học phần: " + ex.Message);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void label56_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void KHMoDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
            
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void label61_Click(object sender, EventArgs e)
        {

        }

        private void LoadKHMoUpdBtn_Click_1(object sender, EventArgs e)
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

        private void KHMoUpdDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn một ô hợp lệ trong DataGridView chưa
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                MessageBox.Show("BẠN CHỌN DÒNG " + e.RowIndex.ToString());
                // Lấy dòng được chọn từ DataGridView
                DataGridViewRow row = KHMoUpdDataGrid.Rows[e.RowIndex];
                oldMaHPKHMO = row.Cells["MAHP"].Value.ToString();
                oldHKKHMO = Convert.ToInt32(row.Cells["HK"].Value);
                oldNamKHMO = Convert.ToInt32(row.Cells["NAM"].Value);
                oldMACTKHMO = row.Cells["MACT"].Value.ToString();

                MaHPKHMoUpdTxt.Text = oldMaHPKHMO;
                HocKyUpdTxt.Text = oldHKKHMO.ToString();
                NamUpdTxt.Text = oldNamKHMO.ToString();
                MaCTKHMoUpdTxt.Text = oldMACTKHMO;
            }
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
                                 MAGV IN (SELECT MANV FROM ADMINQL.NHANSU WHERE MADV = 'DVVPK')";
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

        private void tabPage6_Click(object sender, EventArgs e)
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

        private void label79_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {

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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label80_Click(object sender, EventArgs e)
        {

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
                // Đảm bảo rằng kết nối sẽ được đóng ngay cả khi có ngoại lệ xảy ra
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }
    }
}
