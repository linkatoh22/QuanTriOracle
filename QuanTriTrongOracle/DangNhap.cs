using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;


namespace QuanTriTrongOracle
{
    public partial class DangNhap : Form
    {
        //OracleConnection con;
        //connect conn = new connect();
        public DangNhap()
        {
            InitializeComponent();
            /*
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=sys;PASSWORD=admin;DBA PRIVILEGE=SYSDBA";
            con = new OracleConnection(conStr);*/


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cb_ph.Items.Add("PH1");
            cb_ph.Items.Add("PH2");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void signInButton_Click(object sender, EventArgs e)
        {

            if (cb_ph.SelectedItem != null)
            {
                string ph = cb_ph.SelectedItem.ToString();
                if (ph == "PH1")
                {
                    connect conn = new connect();
                    conn.setConnect(username.Text, password.Text, ph);
                    OracleConnection con = new OracleConnection(new connect().getString());
                    try
                    {
                        con.Open();
                        con.Close();
                        MessageBox.Show("Đăng nhập thành công.");
                        this.Hide();
                        NavForm nav = new NavForm();
                        this.Hide();
                        nav.Show();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        MessageBox.Show("Đăng nhập thất bại");
                    }
                }
                else if (ph == "PH2")
                {
                    string Role;
                    String connect_QLDL = @"DATA SOURCE =localhost:1521/qldlnoibo; USER ID= ADMINQL; PASSWORD=ADMINQL";
                    using (OracleConnection con = new OracleConnection(connect_QLDL))
                    {
                        con.Open();
                        OracleCommand cmd = new OracleCommand("SELECT FUNC_VAITRO(:USRNAME) FROM DUAL", con);

                        // Truyền tham số vào hàm
                        cmd.Parameters.Add("USRNAME", OracleDbType.Varchar2).Value = username.Text;

                        // Nhận giá trị trả về từ hàm
                        Role = cmd.ExecuteScalar()?.ToString();

                    }
                        Console.WriteLine("Role ne " + Role);

                        if (Role != null)
                        {
                            connect conn = new connect();
                            conn.setConnect(username.Text, password.Text, ph);
                            OracleConnection con_NV = new OracleConnection(new connect().getString());
                            try
                            {
                                con_NV.Open();
                                con_NV.Close();
                                MessageBox.Show("Đăng nhập thành công.");
                               
                            this.Hide();

                                switch (Role)
                                {
                                    case "NHANVIENCOBAN":
                                        NavNVCB navNVCB = new NavNVCB();
                                        navNVCB.Show();
                                        break;
                                    case "GIANGVIEN":
                                        NavGV navGV = new NavGV();
                                        navGV.Show();
                                        break;
                                    case "GIAOVU":
                                        Nav_GVU2 navGvu = new Nav_GVU2();
                                        navGvu.Show();
                                        Noti Tb_gvu=new Noti();
                                        Tb_gvu.Show();
                                        break;
                                    case "TRUONGDV":
                                        NavTDV navTDV = new NavTDV();
                                        navTDV.Show();
                                        Noti Tb_tdv = new Noti();
                                        Tb_tdv.Show();
                                        break;
                                    case "TRUONGKHOA":
                                        NavTK navTK = new NavTK();
                                        navTK.Show();
                                        Noti Tb_tk = new Noti();
                                        Tb_tk.Show();
                                        break;
                                    case "SINHVIEN":
                                        NavSC navSC = new NavSC();
                                        navSC.Show();
                                        Noti Tb_sv = new Noti();
                                        Tb_sv.Show();
                                    break;
                                    case "RESOURCE":
                                        NavAD navAD = new NavAD();
                                        navAD.Show();
                                        break;
                                }
                                return;
                                //NavForm nav = new NavForm();
                                //nav.Show();
                            }
                            catch (Exception ex)
                            {
                                con_NV.Close();
                                MessageBox.Show("Đăng nhập thất bại");
                            }
                        }
                        else
                            MessageBox.Show("Đăng nhập thất bại");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn phân hệ");
                }
            }

            private void button1_Click(object sender, EventArgs e)
            {

            }
            /*
            private void updateGrid()
            {
                con.Open();
                OracleCommand getEmps = con.CreateCommand();
                getEmps.CommandText = "SELECT * FROM sys.ATTENDANCE";
                getEmps.CommandType = CommandType.Text;
                OracleDataReader empDR = getEmps.ExecuteReader();
                DataTable empDT = new DataTable();
                empDT.Load(empDR);
                dataGridView1.DataSource = empDT;
                con.Close();
            }*/
        }
    }
