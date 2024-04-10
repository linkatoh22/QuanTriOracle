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

namespace QuanTriTrongOracle.Tab
{
    public partial class ThuHoiQuyen : UserControl
    {
        OracleConnection con;
        public ThuHoiQuyen()
        {
            InitializeComponent();
            // Khởi tạo kết nối Oracle

            // Load dữ liệu từ Oracle vào DataGridView
            LoadDataUser();
            LoadDataRole();
        }
        private void SystemPriRadio_CheckedChanged(object sender, EventArgs e)
        {
            SystemUserlbl.Enabled = true;
            SystemUserDD.Enabled = true;
            SystemPriTxt.Enabled = true;
            SystemPriDD.Enabled = true;
            SystemBtnPri.Enabled = true;
            ObjectObjTxt.Enabled = false;
            ObjectObjDD.Enabled = false;
            ObjectUserPriTxt.Enabled = false;
            ObjectUserDD.Enabled = false;
            ObjectPriDD.Enabled = false;
            ObjectPriTxt.Enabled = false;
            ObjPriBtn.Enabled = false;
        }

        private void ObjectPriRadio_CheckedChanged(object sender, EventArgs e)
        {
            ObjectObjTxt.Enabled = true;
            ObjectObjDD.Enabled = true;
            ObjectUserPriTxt.Enabled = true;
            ObjectUserDD.Enabled = true;
            ObjectPriDD.Enabled = true;
            ObjectPriTxt.Enabled = true;
            ObjPriBtn.Enabled = true;
            SystemUserlbl.Enabled = false;
            SystemUserDD.Enabled = false;
            SystemPriTxt.Enabled = false;
            SystemPriDD.Enabled = false;
            SystemBtnPri.Enabled = false;

        }

        private void LoadDataUser()
        {
            con = connect.getConnection();
            // Mở kết nối
            con.Open();
            try
            {
                string query = "SELECT USERNAME FROM dba_users WHERE USERNAME <> 'SYS'";
                OracleCommand command = new OracleCommand(query, con);
                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SystemUserDD.Items.Add(reader[0]);
                    ObjectUserDD.Items.Add(reader[0]);
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                MessageBox.Show("Error: " + ex.Message);
            }
            con.Close();
        }
        private void LoadDataRole()
        {
            con = connect.getConnection();
            // Mở kết nối
            con.Open();
            try
            {
                string query = "SELECT ROLE FROM dba_roles";
                OracleCommand command = new OracleCommand(query, con);
                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SystemUserDD.Items.Add(reader[0]);
                    ObjectUserDD.Items.Add(reader[0]);
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                MessageBox.Show("Error: " + ex.Message);
            }
            con.Close();
        }
        private void SystemUserDD_SelectedIndexChanged(object sender, EventArgs e)
        {
            con = connect.getConnection();
            // Mở kết nối
            con.Open();
            if (SystemPriDD.SelectedIndex != -1)
            {
                SystemPriDD.Items.RemoveAt(SystemPriDD.SelectedIndex);
            }
            try
            {
                string selectedUsername = SystemUserDD.SelectedItem.ToString();
                string query = "SELECT PRIVILEGE FROM DBA_SYS_PRIVS WHERE GRANTEE = " + "'" + selectedUsername + "'";
                OracleCommand command = new OracleCommand(query, con);
                OracleDataReader reader = command.ExecuteReader();
                SystemPriDD.Items.Clear();
                while (reader.Read())
                {
                    SystemPriDD.Items.Add(reader[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            con.Close();
        }

        private void SystemBtnPri_Click(object sender, EventArgs e)
        {
            con = connect.getConnection();
            // Mở kết nối
            con.Open();

            // Kiểm tra xem có username và privilege được chọn hay không
            if (SystemUserDD.SelectedItem == null || SystemPriDD.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn người dùng và quyền trước khi thực hiện thao tác.");
                con.Close();
                return; // Ngăn chặn việc thực hiện thao tác khi không có giá trị được chọn
            }

            string selectedUsername = SystemUserDD.SelectedItem.ToString();
            string selectedPriv = SystemPriDD.SelectedItem.ToString();
            string query = "REVOKE " + selectedPriv + " FROM " + selectedUsername;
            OracleCommand command = new OracleCommand();
            command.Connection = con;
            command.CommandText = query;
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("THU HỒI QUYỀN THÀNH CÔNG");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            con.Close();
        }

        private void ObjectUserDD_SelectedIndexChanged(object sender, EventArgs e)
        {
            con = connect.getConnection();
            // Mở kết nối
            con.Open();
            
            
            if (ObjectObjDD.SelectedIndex != -1)
            {
                ObjectObjDD.Items.RemoveAt(ObjectObjDD.SelectedIndex);
            }
            

            try
            {
                string selectedUsername = ObjectUserDD.SelectedItem.ToString();
                string query = "SELECT DISTINCT TABLE_NAME FROM DBA_TAB_PRIVS WHERE GRANTEE = '" + selectedUsername + "'";
                OracleCommand command = new OracleCommand(query, con);
                OracleDataReader reader = command.ExecuteReader();
                ObjectObjDD.Items.Clear();
                
                while (reader.Read())
                {
                    ObjectObjDD.Items.Add(reader[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            con.Close();
        }
        private void ObjectObjDD_SelectedIndexChanged(object sender, EventArgs e)
        {
            con = connect.getConnection();
            // Mở kết nối
            con.Open();
            if (ObjectPriDD.SelectedIndex != -1)
            {
                ObjectPriDD.Items.RemoveAt(ObjectPriDD.SelectedIndex);
            }
            try
            {
                string selectedUsername = ObjectUserDD.SelectedItem.ToString();
                string selectedObj = ObjectObjDD.SelectedItem.ToString();
                string query = "SELECT PRIVILEGE FROM DBA_TAB_PRIVS WHERE GRANTEE = " + "'" + selectedUsername + "' AND TABLE_NAME = " + "'" + selectedObj + "'";
                OracleCommand command = new OracleCommand(query, con);
                OracleDataReader reader = command.ExecuteReader();
                ObjectPriDD.Items.Clear();
                while (reader.Read())
                {
                    ObjectPriDD.Items.Add(reader[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            con.Close();
        }
        private void ObjectBtnPri_Click(object sender, EventArgs e)
        {
            con = connect.getConnection();
            // Mở kết nối
            con.Open();
            if (ObjectUserDD.SelectedItem == null || ObjectPriDD.SelectedItem == null || ObjectObjDD.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn người dùng và đối tượng và quyền trước khi thực hiện thao tác.");
                con.Close();
                return;
            }
            string selectedUsername = ObjectUserDD.SelectedItem.ToString();
            string selectedPriv = ObjectPriDD.SelectedItem.ToString();
            string selectedObj = ObjectObjDD.SelectedItem.ToString();
            
            string query = "REVOKE " + selectedPriv + " ON " + selectedObj + " FROM " + selectedUsername;
            OracleCommand command = new OracleCommand();
            command.Connection = con;
            command.CommandText = query;
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("THU HỒI QUYỀN THÀNH CÔNG");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            con.Close();
        }

        private void ThuHoiQuyen_Load(object sender, EventArgs e)
        {

        }
    }
}
