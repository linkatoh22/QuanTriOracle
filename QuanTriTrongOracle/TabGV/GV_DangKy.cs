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

namespace QuanTriTrongOracle.TabGV
{
    public partial class GV_DangKy : UserControl
    {
        OracleConnection con;
        public GV_DangKy()
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
            try
            {
                string masv = textBox7.Text;
                string magv = textBox8.Text;
                string mahp = textBox9.Text;
                string mact = textBox1.Text;
                int hk = int.Parse(textBox10.Text);
                int nam = int.Parse(textBox6.Text);
                decimal diemThi = decimal.Parse(textBox2.Text);
                decimal diemQt = decimal.Parse(textBox3.Text);
                decimal diemCk = decimal.Parse(textBox4.Text);
                decimal diemTk = decimal.Parse(textBox5.Text);

                OracleConnection con = connect.getConnection();
                con.Open();

                using (OracleCommand cmd = new OracleCommand("ADMINQL.PROC_UPDATE_DIEMSO", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_MASV", OracleDbType.Varchar2).Value = masv;
                    cmd.Parameters.Add("p_MAGV", OracleDbType.Varchar2).Value = magv;
                    cmd.Parameters.Add("p_MAHP", OracleDbType.Varchar2).Value = mahp;
                    cmd.Parameters.Add("p_HK", OracleDbType.Int32).Value = hk;// Sử dụng OracleDbType.Decimal
                    cmd.Parameters.Add("p_NAM", OracleDbType.Decimal).Value = nam;
                    cmd.Parameters.Add("p_MACT", OracleDbType.Varchar2).Value = mact;
                    cmd.Parameters.Add("p_DIEMTHI", OracleDbType.Decimal).Value = diemThi;
                    cmd.Parameters.Add("p_DIEMQT", OracleDbType.Decimal).Value = diemQt;
                    cmd.Parameters.Add("p_DIEMCK", OracleDbType.Decimal).Value = diemCk;
                    cmd.Parameters.Add("p_DIEMTK", OracleDbType.Decimal).Value = diemTk;

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật điểm số thành công.");
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
