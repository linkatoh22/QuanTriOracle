using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace QuanTriTrongOracle.Tab
{
    public partial class PhanQuyen : UserControl
    {
        string table_ptu;
        string table_ptr;
        public PhanQuyen()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PhanQuyen_Load(object sender, EventArgs e)
        {
            cb_priv_ptu.Items.Add("SELECT");
            cb_priv_ptu.Items.Add("UPDATE");
            cb_priv_ptu.Items.Add("INSERT");
            cb_priv_ptu.Items.Add("DELETE");
            cbUserRtu_Load();
            cbUserPtu_Load();
            cbRoleRtu_Load();
            cbRolePtr_Load();
            cb_priv_ptr.Items.Add("SELECT");
            cb_priv_ptr.Items.Add("UPDATE");
            cb_priv_ptr.Items.Add("INSERT");
            cb_priv_ptr.Items.Add("DELETE");




        }
        private void cbUserRtu_Load()
        {
            OracleConnection con = new OracleConnection(new connect().getString());
            OracleCommand cmd = new OracleCommand("select USERNAME from dba_users " +
                "where created > (select created + interval '30' minute from v$database) order by 1", con);
            con.Open();
            cmd.ExecuteNonQuery();
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string username = dr["USERNAME"].ToString();
                cb_user_rtu.Items.Add(username);
            }
            con.Close();
        }

        private void cbUserPtu_Load()
        {
            OracleConnection con = new OracleConnection(new connect().getString());
            OracleCommand cmd = new OracleCommand("select USERNAME from dba_users " +
                "where created > (select created + interval '30' minute from v$database) order by 1", con);
            con.Open();
            cmd.ExecuteNonQuery();
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string username = dr["USERNAME"].ToString();
                cb_user_ptu.Items.Add(username);
            }
            con.Close();
        }

        private void cbRoleRtu_Load()
        {
            OracleConnection con = new OracleConnection(new connect().getString());
            OracleCommand cmd = new OracleCommand("select ROLE from dba_roles", con);
            con.Open();
            cmd.ExecuteNonQuery();
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string username = dr["ROLE"].ToString();
                cb_role_rtu.Items.Add(username);
            }
            con.Close();
        }
        private void cbRolePtr_Load()
        {
            OracleConnection con = new OracleConnection(new connect().getString());
            OracleCommand cmd = new OracleCommand("select ROLE from dba_roles", con);
            con.Open();
            cmd.ExecuteNonQuery();
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string username = dr["ROLE"].ToString();
                cb_role_ptr.Items.Add(username);
            }
            con.Close();
        }

        private void cbCollPtu_Load()
        {
            OracleConnection con = new OracleConnection(new connect().getString());
            OracleCommand cmd = new OracleCommand("SELECT COLUMN_NAME " +
                "FROM USER_TAB_COLUMNS WHERE table_name ='" + table_ptu + "'", con);
            Console.WriteLine(table_ptu);
            con.Open();
            cmd.ExecuteNonQuery();
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string username = dr["COLUMN_NAME"].ToString();
                cb_coll_ptu.Items.Add(username);
            }
            con.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cb_table_ptu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_find_ptu_Click(object sender, EventArgs e)
        {

            OracleConnection con = new OracleConnection(new connect().getString());
            OracleCommand cmd = new OracleCommand("FIND_TABLE", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("TABLENAME", "varchar2").Value = (txtbox_ptu.Text).ToUpper();
            cmd.Parameters.Add("THONGBAO", OracleDbType.Varchar2, 4000, null, ParameterDirection.Output);

            if (txtbox_ptu.Text != "")
            {
                cmd.ExecuteNonQuery();
                string outParamValue = cmd.Parameters["THONGBAO"].Value.ToString();
                if (outParamValue == "YES")
                {
                    table_ptu = (txtbox_ptu.Text).ToUpper();
                    con.Close();
                    cbCollPtu_Load();
                    MessageBox.Show("Đã load cột của bảng");
                }
                else
                {
                    MessageBox.Show("Bảng không tông tại");
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Không được để ô table trống khi tìm bảng");
                con.Close();
            }

        }

        private void cb_priv_ptr_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_rtu_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection(new connect().getString());
            OracleCommand cmd = new OracleCommand("GRANT_ROLE_USER", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("ROLE_USR", "varchar2").Value = cb_role_rtu.SelectedItem.ToString();
            cmd.Parameters.Add("USERNAME_USR", "varchar2").Value = cb_user_rtu.SelectedItem.ToString();

            if (cb_role_rtu.SelectedItem.ToString() != "" && cb_role_rtu.SelectedItem.ToString() != "")
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cấp role cho user thành công");
            }
            else
            {
                MessageBox.Show("Không được để thông tin trống");
            }

            con.Close();
        }

        private void btn_ptu_Click(object sender, EventArgs e)
        {

            string username = cb_user_ptu.SelectedItem.ToString();
            string priv = cb_priv_ptu.SelectedItem.ToString();
            string table = (txtbox_ptu.Text).ToUpper();
            string coll;
            if (cb_coll_ptu.SelectedItem == null)
            {
                coll = "EMPTY";
            }
            else
                coll = cb_coll_ptu.SelectedItem.ToString();
            string grant_op;
            bool grant = checkbx_ptu.Checked;

            if (grant == true)
            {
                grant_op = "TRUE1";
            }
            else
            {
                grant_op = "FALSE1";
            }
            Console.WriteLine("GRAND_OP " + grant_op);
            Console.WriteLine("COL " + coll);
            OracleConnection con = new OracleConnection(new connect().getString());
            OracleCommand cmd = new OracleCommand("GRANT_PRIVS_USR", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("USERNAME_USR", "varchar2").Value = username;
            cmd.Parameters.Add("PRIVS_USR", "varchar2").Value = priv;
            cmd.Parameters.Add("TABLE_NAME", "varchar2").Value = table;
            cmd.Parameters.Add("GRANT_OPTION", "varchar2").Value = grant_op;
            cmd.Parameters.Add("COLL_USR", "varchar2").Value = coll;
            if (username != "" && priv != "" && table != "")
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cấp quyền cho user thành công");
            }
            else
            {
                MessageBox.Show("Không được để thông tin trống");
            }

            con.Close();
        }

        private void btn_ptr_Click(object sender, EventArgs e)
        {
            string role = cb_role_ptr.SelectedItem.ToString();
            string priv = cb_priv_ptr.SelectedItem.ToString();
            string table = (txtbox_ptr.Text).ToUpper();
            string coll;
            if (cb_coll_ptr.SelectedItem == null)
            {
                coll = "EMPTY";
            }
            else
                coll = cb_coll_ptr.SelectedItem.ToString();
            Console.WriteLine("COL " + coll);
            OracleConnection con = new OracleConnection(new connect().getString());
            OracleCommand cmd = new OracleCommand("GRANT_PRIVS_ROLE", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("ROLE_USR", "varchar2").Value = role;
            cmd.Parameters.Add("PRIVS_USR", "varchar2").Value = priv;
            cmd.Parameters.Add("TABLE_NAME", "varchar2").Value = table;
            cmd.Parameters.Add("COLL_USR", "varchar2").Value = coll;
            if (role != "" && priv != "" && table != "")
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cấp quyền cho Role thành công");
            }
            else
            {
                MessageBox.Show("Không được để thông tin trống");
            }

            con.Close();
        }

        private void find_ptr_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection(new connect().getString());
            OracleCommand cmd = new OracleCommand("FIND_TABLE", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("TABLENAME", "varchar2").Value = (txtbox_ptr.Text).ToUpper();
            cmd.Parameters.Add("THONGBAO", OracleDbType.Varchar2, 4000, null, ParameterDirection.Output);

            if (txtbox_ptr.Text != "")
            {
                cmd.ExecuteNonQuery();
                string outParamValue = cmd.Parameters["THONGBAO"].Value.ToString();
                if (outParamValue == "YES")
                {
                    table_ptr = (txtbox_ptr.Text).ToUpper();
                    con.Close();
                    cbCollPtr_Load();
                    MessageBox.Show("Đã load cột của bảng");
                }
                else
                {
                    MessageBox.Show("Bảng không tông tại");
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Không được để ô table trống khi tìm bảng");
                con.Close();
            }
        }
        private void cbCollPtr_Load()
        {
            OracleConnection con = new OracleConnection(new connect().getString());
            OracleCommand cmd = new OracleCommand("SELECT COLUMN_NAME " +
                "FROM USER_TAB_COLUMNS WHERE table_name ='" + table_ptr + "'", con);
            Console.WriteLine(table_ptr);
            con.Open();
            cmd.ExecuteNonQuery();
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string username = dr["COLUMN_NAME"].ToString();
                cb_coll_ptr.Items.Add(username);
            }
            con.Close();
        }
    }
}
