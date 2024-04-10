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
    public partial class EditUserRole : UserControl
    {

        public EditUserRole()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void createuser_pass_TextChanged(object sender, EventArgs e)
        {

        }


        private void btn_CreateUser_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection(new connect().getString());
            OracleCommand cmd = new OracleCommand("CREATE_NEWUSER", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("USERNAME_USR", "varchar2").Value = createuser_name.Text;
            cmd.Parameters.Add("PASSWORD_USR", "varchar2").Value = createuser_pass.Text;

            if (createuser_pass.Text != "" && createuser_name.Text != "")
            {
                cmd.ExecuteNonQuery();
                createuser_name.ResetText();
                createuser_pass.ResetText();
                MessageBox.Show("Tạo User thành công");
                username_comboBoxLoad();
                Role_comboBoxLoad();
                edt_usr_comboBoxLoad();
                edt_role_comboBoxLoad();
            }
            else
            {
                MessageBox.Show("Để tạo user không được để username hoặc password trống!");
            }

            con.Close();
        }

        private void role_password_create_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection(new connect().getString());
            OracleCommand cmd = new OracleCommand("CREATE_ROLE", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            string pass;
            if (role_username_create.Text != "")
            {
                pass = role_password_create.Text;

                if (role_password_create.Text == "")
                {
                    pass = " ";

                }
                cmd.Parameters.Add("ROLE_USR", "varchar2").Value = role_username_create.Text;
                cmd.Parameters.Add("PASSWORD_USR", "varchar2").Value = pass;
                role_username_create.ResetText();
                role_password_create.ResetText();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Tạo role thành công!");
                username_comboBoxLoad();
                Role_comboBoxLoad();
                edt_usr_comboBoxLoad();
                edt_role_comboBoxLoad();
            }
            else
            {
                MessageBox.Show("Để tạo role không được để tên role trống!");
            }
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void EditUserRole_Load(object sender, EventArgs e)
        {
            username_comboBoxLoad();
            Role_comboBoxLoad();
            edt_usr_comboBoxLoad();
            edt_role_comboBoxLoad();


        }

        private void btn_deleteUser_Click(object sender, EventArgs e)
        {
            String userName = comboBox1.SelectedItem.ToString();
            if (userName != "")
            {
                OracleConnection con = new OracleConnection(new connect().getString());
                OracleCommand cmd = new OracleCommand("DELETE_USER", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("USERNAME_USR", "varchar2").Value = userName;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Xóa thành công!");
                username_comboBoxLoad();
                edt_usr_comboBoxLoad();
            }
            else
                MessageBox.Show("Để xóa role không được để tên role trống!");
        }
        private void username_comboBoxLoad()
        {
            OracleConnection con = new OracleConnection(new connect().getString());
            OracleCommand cmd = new OracleCommand("select username from dba_users where created > (select created + interval '30' minute from v$database) order by 1", con);
            con.Open();
            cmd.ExecuteNonQuery();
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string username = dr["USERNAME"].ToString();
                comboBox1.Items.Add(username);
            }
            con.Close();
        }
        private void Role_comboBoxLoad()
        {
            OracleConnection con = new OracleConnection(new connect().getString());
            OracleCommand cmd2 = new OracleCommand("SELECT ROLE FROM DBA_ROLES", con);
            con.Open();
            cmd2.ExecuteNonQuery();
            OracleDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                string role = dr2["ROLE"].ToString();
                comboBox2.Items.Add(role);
            }
            con.Close();

        }

        private void edt_usr_comboBoxLoad()
        {
            OracleConnection con = new OracleConnection(new connect().getString());
            OracleCommand cmd = new OracleCommand("select username from dba_users where created > (select created + interval '30' minute from v$database) order by 1", con);
            con.Open();
            cmd.ExecuteNonQuery();
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string username = dr["USERNAME"].ToString();
                edt_usr.Items.Add(username);
            }
            con.Close();
        }

        private void edt_role_comboBoxLoad()
        {
            OracleConnection con = new OracleConnection(new connect().getString());
            OracleCommand cmd2 = new OracleCommand("SELECT ROLE FROM DBA_ROLES", con);
            con.Open();
            cmd2.ExecuteNonQuery();
            OracleDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                string role = dr2["ROLE"].ToString();
                edt_role.Items.Add(role);
            }
            con.Close();

        }

        private void btn_deleteRole_Click(object sender, EventArgs e)
        {
            String Role = comboBox2.SelectedItem.ToString();
            if (Role != "")
            {
                OracleConnection con = new OracleConnection(new connect().getString());
                OracleCommand cmd = new OracleCommand("DELETE_ROLE", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("ROLE_USR", "varchar2").Value = Role;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Role_comboBoxLoad();
                edt_role_comboBoxLoad();
                MessageBox.Show("Xóa thành công!");
            }
            else
                MessageBox.Show("Để xóa role không được để tên role trống!");
        }

        private void edt_usr_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Upd_User_Click(object sender, EventArgs e)
        {
            String username = edt_usr.SelectedItem.ToString();

            if (username != "")
            {
                OracleConnection con = new OracleConnection(new connect().getString());
                OracleCommand cmd = new OracleCommand("UPDATE_USER", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("USERNAME_USR", "varchar2").Value = username;
                cmd.Parameters.Add("PASSWORD_USR", "varchar2").Value = edit_passuser.Text;

                if (edit_passuser.Text != "")
                {
                    cmd.ExecuteNonQuery();
                    createuser_name.ResetText();
                    createuser_pass.ResetText();
                    MessageBox.Show("Chỉnh mật khẩu User thành công");
                }
                else
                {
                    MessageBox.Show("Để chỉnh mật khẩu user không được để password trống!");
                }

                con.Close();
            }
            else
                MessageBox.Show("Để xóa role không được để tên role trống!");
        }

        private void Upd_Role_Click(object sender, EventArgs e)
        {
            String ROLE = edt_role.SelectedItem.ToString();

            if (ROLE != "")
            {
                OracleConnection con = new OracleConnection(new connect().getString());
                OracleCommand cmd = new OracleCommand("UPDATE_ROLE", con);
                con.Open();

                if (edit_passuser.Text != "")
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("ROLENAME_USR", "varchar2").Value = ROLE;
                    cmd.Parameters.Add("PASSWORD_USR", "varchar2").Value = edit_role.Text;
                    cmd.ExecuteNonQuery();
                    createuser_name.ResetText();
                    createuser_pass.ResetText();
                    MessageBox.Show("Chỉnh mật khẩu Role thành công");
                }

                else
                {
                    String pass = " ";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("ROLENAME_USR", "varchar2").Value = ROLE;
                    cmd.Parameters.Add("PASSWORD_USR", "varchar2").Value = pass;
                    cmd.ExecuteNonQuery();
                    createuser_name.ResetText();
                    createuser_pass.ResetText();
                    MessageBox.Show("Chỉnh mật khẩu Role thành công");
                }

                con.Close();
            }
            else
                MessageBox.Show("Để xóa role không được để tên role trống!");
        }
    }
}
