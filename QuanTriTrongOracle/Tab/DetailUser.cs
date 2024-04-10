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
    public partial class DetailUser : UserControl
    {
        OracleConnection con;
        public DetailUser()
        {
            InitializeComponent();

            LoadDataUser();
            LoadDataRole();
        }

        private void LoadDataUser()
        {
            con = connect.getConnection();
            con.Open();
            try
            {
                string query = "SELECT USERNAME FROM dba_users WHERE USERNAME <> 'SYS'";
                OracleCommand command = new OracleCommand(query, con);
                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    UserDD.Items.Add(reader[0]);
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
            con.Open();
            try
            {
                string query = "SELECT ROLE FROM dba_roles";
                OracleCommand command = new OracleCommand(query, con);
                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    UserDD.Items.Add(reader[0]);
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
            if (SystemRad.Checked) {
                SystemRad.Checked = false;
                SystemRad.Checked = true;
            }
            else if (ObjectRad.Checked)
            {
                ObjectRad.Checked = false;
                ObjectRad.Checked = true;
            }

        }
        private void SystemPriRadio_CheckedChanged(object sender, EventArgs e)
        {
            con = connect.getConnection();
            con.Open();
            try
            {
                if(UserDD.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn người dùng trước khi thực hiện thao tác.");
                    con.Close();
                    return; // Ngăn chặn việc thực hiện thao tác khi không có giá trị được chọn
                }
                string selectedUsername = UserDD.SelectedItem.ToString();
                string query = "SELECT GRANTEE, PRIVILEGE, ADMIN_OPTION FROM DBA_SYS_PRIVS where grantee = " + "'" + selectedUsername + "'";
                using (OracleCommand cmd = new OracleCommand(query, con))
                {
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        PriList.DataSource = dataTable;
                        foreach (DataGridViewColumn column in PriList.Columns)
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
        private void ObjectPriRadio_CheckedChanged(object sender, EventArgs e)
        {
            con = connect.getConnection();
            con.Open();
            try
            {
                if (UserDD.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn người dùng trước khi thực hiện thao tác.");
                    return;
                }

                string selectedUsername = UserDD.SelectedItem.ToString();
                string query = @"
                    SELECT A.*
                    FROM (
                        SELECT grantee AS username,
                            granted_role AS privilege,
                            '--' AS owner,
                            '--' AS table_name,
                            '--' AS column_name,
                            admin_option AS admin_option,
                            'ROLE' AS access_type
                        FROM dba_role_privs RP
                        JOIN dba_roles R ON RP.granted_role = R.role
                        WHERE grantee IN (SELECT username FROM dba_users WHERE username = :selectedUsername)

                        UNION

                        SELECT grantee AS username,
                            privilege AS privilege,
                            '--' AS owner,
                            '--' AS table_name,
                            '--' AS column_name,
                            admin_option AS admin_option,
                            'SYSTEM' AS access_type
                        FROM dba_sys_privs
                        WHERE grantee IN (SELECT username FROM dba_users WHERE username = :selectedUsername)

                        UNION

                        SELECT grantee AS username,
                            privilege AS privilege,
                            owner AS owner,
                            table_name AS table_name,
                            '--' AS column_name,
                            grantable AS admin_option,
                            'TABLE' AS access_type
                        FROM dba_tab_privs
                        WHERE grantee IN (SELECT username FROM dba_users WHERE username = :selectedUsername)

                        UNION

                        SELECT DP.grantee AS username,
                            privilege AS privilege,
                            owner AS owner,
                            table_name AS table_name,
                            column_name AS column_name,
                            '--' AS admin_option,
                            'ROLE' AS access_type
                        FROM role_tab_privs RP
                        JOIN dba_role_privs DP ON RP.role = DP.granted_role
                        WHERE DP.grantee IN (SELECT username FROM dba_users WHERE username = :selectedUsername)

                        UNION

                        SELECT grantee AS username,
                            privilege AS privilege,
                            grantable AS admin_option,
                            owner AS owner,
                            table_name AS table_name,
                            column_name AS column_name,
                            'COLUMN' AS access_type
                        FROM dba_col_privs
                        WHERE grantee IN (SELECT username FROM dba_users WHERE username = :selectedUsername)
                    ) A
                    ORDER BY username, A.table_name, 
                             CASE
                                WHEN A.access_type = 'SYSTEM' THEN 1
                                WHEN A.access_type = 'TABLE' THEN 2
                                WHEN A.access_type = 'COLUMN' THEN 3
                                WHEN A.access_type = 'ROLE' THEN 4
                             END,
                             CASE
                                WHEN A.privilege IN ('EXECUTE') THEN 1
                                WHEN A.privilege IN ('SELECT', 'INSERT', 'DELETE') THEN 3
                                ELSE 2
                             END,
                             A.column_name, A.privilege";

                using (OracleCommand cmd = new OracleCommand(query, con))
                {
                    cmd.Parameters.Add(new OracleParameter("selectedUsername", selectedUsername));
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        PriList.DataSource = dataTable;
                        foreach (DataGridViewColumn column in PriList.Columns)
                        {
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            con.Close();
        }




        private void DetailUser_Load(object sender, EventArgs e)
        {

        }
    }
}

