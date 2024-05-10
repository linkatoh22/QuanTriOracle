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
    public partial class NavTK : Form
    {
        OracleConnection con;
        //PHANCONG, biến để lưu các giá trị cũ để có thể cập nhật dễ dàng hơn
        private string oldMaGVPC;
        private string oldMaHPPC;
        private int oldHKPC;
        private int oldNamPC;
        private string oldMaCTPC;
        public NavTK()
        {
            InitializeComponent();
        }

        private void NavGV_Load(object sender, EventArgs e)
        {

        }

        private void label69_Click(object sender, EventArgs e)
        {

        }

        private void MaCTPCUpdTxt_TextChanged(object sender, EventArgs e)
        {

        }




        private void LoadPCUpdBtn_Click(object sender, EventArgs e)
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
                MaGVPCUpdTxt.Text = row.Cells["MAGV"].Value.ToString();
                MaHPPCUpdTxt.Text = row.Cells["MAHP"].Value.ToString();
                HKPCUpdTxt.Text = Convert.ToInt32(row.Cells["HK"].Value).ToString();
                NamPCUpdTxt.Text = Convert.ToInt32(row.Cells["NAM"].Value).ToString();
                MaCTPCUpdTxt.Text = row.Cells["MACT"].Value.ToString();
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

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void LoadPCDelBtn_Click(object sender, EventArgs e)
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
                        PCDelDataGrid.DataSource = dataTable;
                        foreach (DataGridViewColumn column in PCDelDataGrid.Columns)
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

        private void PCDelDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                MessageBox.Show("BẠN CHỌN DÒNG " + e.RowIndex.ToString());
                // Lấy dòng được chọn từ DataGridView
                DataGridViewRow row = PCDelDataGrid.Rows[e.RowIndex];
                MaGVPCDelTxt.Text = row.Cells["MAGV"].Value.ToString();
                MaHPPCDelTxt.Text = row.Cells["MAHP"].Value.ToString();
                HKPCDelTxt.Text = Convert.ToInt32(row.Cells["HK"].Value).ToString();
                NamPCDelTxt.Text = Convert.ToInt32(row.Cells["NAM"].Value).ToString();
                MaCTPCDelTxt.Text = row.Cells["MACT"].Value.ToString();
            }
        }
        private void DeletePCBtn_Click(object sender, EventArgs e)
        {
            string magv = MaGVPCDelTxt.Text;
            string mahp = MaHPPCDelTxt.Text;
            int hk = int.Parse(HKPCDelTxt.Text);
            int nam = int.Parse(NamPCDelTxt.Text);
            string mact = MaCTPCDelTxt.Text;

            OracleConnection con = null;
            try
            {
                // Tạo kết nối
                con = connect.getConnection();
                con.Open();

                // Tạo và thực thi command
                using (OracleCommand cmd = new OracleCommand("ADMINQL.PROC_DELETE_PHANCONG", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm các tham số
                    cmd.Parameters.Add("p_MAGV", OracleDbType.Varchar2).Value = magv;
                    cmd.Parameters.Add("p_MAHP", OracleDbType.Varchar2).Value = mahp;
                    cmd.Parameters.Add("p_HK", OracleDbType.Int32).Value = hk;
                    cmd.Parameters.Add("p_NAM", OracleDbType.Decimal).Value = nam;
                    cmd.Parameters.Add("p_MACT", OracleDbType.Varchar2).Value = mact;

                    // Thực thi truy vấn
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Dữ liệu đã được xóa thành công.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message);
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

        private void LoadHPPCBtn_Click(object sender, EventArgs e)
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
                        HPPCDataGrid.DataSource = dataTable;
                        foreach (DataGridViewColumn column in HPPCDataGrid.Columns)
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

        private void HPPCDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                MessageBox.Show("BẠN CHỌN DÒNG " + e.RowIndex.ToString());
                // Lấy dòng được chọn từ DataGridView
                DataGridViewRow row = HPPCDataGrid.Rows[e.RowIndex];
                MaHPPCInsTxt.Text = row.Cells["MAHP"].Value.ToString();
                HKPCInsTxt.Text = Convert.ToInt32(row.Cells["HK"].Value).ToString();
                NamPCInsTxt.Text = Convert.ToInt32(row.Cells["NAM"].Value).ToString();
                MaCTPCInsTxt.Text = row.Cells["MACT"].Value.ToString();
            }
        }

        private void InsertPCBtn_Click(object sender, EventArgs e)
        {
            string magv = MaGVPCInsTxt.Text;
            string mahp = MaHPPCInsTxt.Text;
            int hk = int.Parse(HKPCInsTxt.Text);
            int nam = int.Parse(NamPCInsTxt.Text);
            string mact = MaCTPCInsTxt.Text;

            OracleConnection con = null;
            try
            {
                // Tạo kết nối
                con = connect.getConnection();
                con.Open();

                // Tạo và thực thi command
                using (OracleCommand cmd = new OracleCommand("ADMINQL.PROC_INSERT_PHANCONG", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm các tham số
                    cmd.Parameters.Add("p_MAGV", OracleDbType.Varchar2).Value = magv;
                    cmd.Parameters.Add("p_MAHP", OracleDbType.Varchar2).Value = mahp;
                    cmd.Parameters.Add("p_HK", OracleDbType.Int32).Value = hk;
                    cmd.Parameters.Add("p_NAM", OracleDbType.Decimal).Value = nam;
                    cmd.Parameters.Add("p_MACT", OracleDbType.Varchar2).Value = mact;
                    // Thực thi truy vấn
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Dữ liệu đã được xóa thành công.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chèn dữ liệu: " + ex.Message);
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

        private void NganhTxt_TextChanged(object sender, EventArgs e)
        {

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

        private void tabPage2_Click(object sender, EventArgs e)
        {

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

        private void TableNameCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy tên bảng từ ComboBox
            string selectedTableName = TableNameCB.SelectedItem.ToString();
            MessageBox.Show(selectedTableName);

            con = connect.getConnection();
            con.Open();
            try
            {
                string query = "SELECT * FROM ADMINQL." + selectedTableName;
               
                using (OracleCommand cmd = new OracleCommand(query, con))
                {
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        TableDataGrid.DataSource = dataTable;
                        foreach (DataGridViewColumn column in TableDataGrid.Columns)
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

        private void LoadTableBtn_Click(object sender, EventArgs e)
        {
            // Thêm các mục vào ComboBox
            TableNameCB.Items.Add("NHANSU");
            TableNameCB.Items.Add("SINHVIEN");
            TableNameCB.Items.Add("DONVI");
            TableNameCB.Items.Add("HOCPHAN");
            TableNameCB.Items.Add("KHMO");
            TableNameCB.Items.Add("PHANCONG");
            TableNameCB.Items.Add("DANGKY");

            // Chọn mục mặc định (nếu cần)
            TableNameCB.SelectedIndex = 0; // Chọn mục đầu tiên
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void TableDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
