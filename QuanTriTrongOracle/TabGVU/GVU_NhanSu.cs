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
    public partial class GVU_NhanSu : UserControl
    {
        OracleConnection con;
        public GVU_NhanSu()
        {
            InitializeComponent();
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
    }
}
