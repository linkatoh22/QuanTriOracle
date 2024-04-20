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

namespace QuanTriTrongOracle.TabTDV
{
    public partial class TDV_DangKy : UserControl
    {
        OracleConnection con;
        public TDV_DangKy()
        {
            InitializeComponent();
            this.GVDataGrid.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
        }


        //TAB2

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                // Lấy chỉ số của dòng được chọn
                int rowIndex = e.RowIndex;

                // Kiểm tra xem chỉ số dòng có hợp lệ không
                if (rowIndex >= 0 && rowIndex < GVDataGrid.Rows.Count)
                {
                    // Lấy thông tin từ dòng được chọn
                    DataGridViewRow selectedRow = GVDataGrid.Rows[rowIndex];

                    // Cập nhật các textbox với thông tin từ dòng được chọn
                    textBox7.Text = selectedRow.Cells["MASV"].Value.ToString(); // Mã SV
                    textBox8.Text = selectedRow.Cells["MAGV"].Value.ToString(); // Mã GV
                    textBox9.Text = selectedRow.Cells["MAHP"].Value.ToString(); // Mã HP
                    textBox10.Text = selectedRow.Cells["HK"].Value.ToString(); // Học kỳ
                    textBox6.Text = selectedRow.Cells["NAM"].Value.ToString(); // Năm
                    textBox1.Text = selectedRow.Cells["MACT"].Value.ToString(); // Mã CT
                    textBox2.Text = selectedRow.Cells["DIEMTHI"].Value.ToString();
                    textBox3.Text = selectedRow.Cells["DIEMQT"].Value.ToString(); 
                    textBox4.Text = selectedRow.Cells["DIEMCK"].Value.ToString(); 
                    textBox5.Text = selectedRow.Cells["DIEMTK"].Value.ToString(); 
            }
            // Thêm sự kiện CellClick vào GVDataGrid
            this.GVDataGrid.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
        }

        private void LoadSVBtn_Click(object sender, EventArgs e)
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
                        GVDataGrid.DataSource = dataTable;
                        foreach (DataGridViewColumn column in GVDataGrid.Columns)
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
        
        private void UpdateDiem_Click(object sender, EventArgs e)
        {
            
            string diemThi1  = textBox2.Text;
            string diemQT1 = textBox3.Text;
            string diemCK1 = textBox4.Text;
            string diemTK1 = textBox5.Text;

            // Kiểm tra xem các trường thông tin đã được nhập đủ chưa
            if (diemThi1.Length == 0 || diemQT1.Length == 0 || diemCK1.Length == 0 || diemTK1.Length == 0) {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            } 

            // Lấy dữ liệu từ các TextBox và chuyển đổi sang dạng số
            decimal diemThi = decimal.Parse(textBox2.Text);
            decimal diemQt = decimal.Parse(textBox3.Text);
            decimal diemCk = decimal.Parse(textBox4.Text);
            decimal diemTk = decimal.Parse(textBox5.Text);

            // Kiểm tra dữ liệu hợp lệ (ví dụ: có thể thêm kiểm tra để đảm bảo rằng điểm nằm trong khoảng từ 0 đến 10)

            // Thực hiện cập nhật vào cơ sở dữ liệu
            try
            {
                con = connect.getConnection();
                con.Open();

                using (OracleCommand cmd = new OracleCommand("ADMINQL.PROC_UPDATE_DIEMSO", con))
                {
                    cmd.Parameters.Add(":diemThi", OracleDbType.Decimal).Value = diemThi;
                    cmd.Parameters.Add(":diemQt", OracleDbType.Decimal).Value = diemQt;
                    cmd.Parameters.Add(":diemCk", OracleDbType.Decimal).Value = diemCk;
                    cmd.Parameters.Add(":diemTk", OracleDbType.Decimal).Value = diemTk;
                    cmd.Parameters.Add(":maSv", OracleDbType.Varchar2).Value = textBox7.Text;
                    cmd.Parameters.Add(":maGv", OracleDbType.Varchar2).Value = textBox8.Text;
                    cmd.Parameters.Add(":maHp", OracleDbType.Varchar2).Value = textBox9.Text;
                    cmd.Parameters.Add(":hocKy", OracleDbType.Int32).Value = textBox10.Text;
                    cmd.Parameters.Add(":nam", OracleDbType.Decimal).Value = textBox6.Text;
                    cmd.Parameters.Add(":maCT", OracleDbType.Varchar2).Value = textBox1.Text;

                    int rowsUpdated = cmd.ExecuteNonQuery();
                    if (rowsUpdated > 0)
                    {
                        MessageBox.Show("Cập nhật điểm số thành công.");
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu nào được cập nhật.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật điểm số: " + ex.Message);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
    }
}
