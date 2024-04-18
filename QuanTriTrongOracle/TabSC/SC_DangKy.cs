using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace QuanTriTrongOracle.TabSC
{
    public partial class SC_DangKy : UserControl
    {
        OracleConnection con = new OracleConnection(new connect().getString());
        public SC_DangKy()
        {
            InitializeComponent();
            updateGrid();
            dangkyhp_load();
            hp_in.Enabled = false;
        }
        private void updateGrid()
        {
            con.Open();
            OracleCommand getEmps = con.CreateCommand();
            getEmps.CommandText = "SELECT * FROM ADMINQL.DANGKY";
            getEmps.CommandType = CommandType.Text;
            OracleDataReader empDR = getEmps.ExecuteReader();
            DataTable empDT = new DataTable();
            empDT.Load(empDR);
            dataGridView1.DataSource = empDT;
            binding();
            con.Close();
        }

        private void binding()
        {
            mahp_del.DataBindings.Clear();
            mahp_del.DataBindings.Add("Text", dataGridView1.DataSource, "MAHP");
            hk_del.DataBindings.Clear();
            hk_del.DataBindings.Add("Text", dataGridView1.DataSource, "HK");
            nam_del.DataBindings.Clear();
            nam_del.DataBindings.Add("Text", dataGridView1.DataSource, "NAM");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            OracleCommand cmd = new OracleCommand("ADMINQL.PROC_DEL_DANGKY", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("MAHOCPHAN", "varchar2").Value = mahp_del.Text;
            cmd.Parameters.Add("HOCKY", "INT").Value = int.Parse(hk_del.Text);
            cmd.Parameters.Add("NAM1", "NUMBER").Value = int.Parse(nam_del.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Xóa thành công");
            con.Close();
            updateGrid();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void dangkyhp_load()
        {
            OracleCommand cmd_dangky = new OracleCommand("select MAHP from ADMINQL.HOCPHAN", con);
            con.Open();
            cmd_dangky.ExecuteNonQuery();
            OracleDataReader dr = cmd_dangky.ExecuteReader();
            while (dr.Read())
            {
                string username = dr["MAHP"].ToString();
                mahp_in.Items.Add(username);
            }

            con.Close();

        }

        private void mahp_in_SelectedIndexChanged(object sender, EventArgs e)
        {
            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;
            int currentDay = DateTime.Now.Day;
            if (currentDay < 20)
            {
                if (currentMonth == 4 || currentMonth == 5 || currentMonth == 9)
                {
                    switch(currentMonth)
                    {
                        case 4:
                            hk_in.Text = "1";
                            nam_in.Text = currentYear.ToString();
                            break;
                        case 5:
                            hk_in.Text = "2";
                            nam_in.Text = currentYear.ToString();
                            break;
                        case 9:
                            hk_in.Text = "2";
                            nam_in.Text = currentYear.ToString();
                            break;

                    }
                    hp_in.Enabled = true;
                    return;
                }
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void nam_in_TextChanged(object sender, EventArgs e)
        {

        }

        private void hp_in_Click(object sender, EventArgs e)
        {
            con.Open();
            OracleCommand cmd = new OracleCommand("ADMINQL.PROC_IN_DANGKY_SV", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("MAHOCPHAN", "varchar2").Value = mahp_in.Text;
            cmd.Parameters.Add("HOCKY", "INT").Value = int.Parse(hk_in.Text);
            cmd.Parameters.Add("NAM1", "NUMBER").Value = int.Parse(nam_in.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Đăng ký học phần thành công");
            con.Close();
            updateGrid();
        }
    }
}
