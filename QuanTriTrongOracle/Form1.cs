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

namespace QuanTriTrongOracle
{
    public partial class Form1 : Form
    {
        connect conn = new connect();
        public Form1()
        {
            InitializeComponent();
            //string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=sys;PASSWORD=admin;DBA PRIVILEGE=SYSDBA";
            //con = new OracleConnection(conStr);
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
            conn.setConnect(username.Text, password.Text);
            OracleConnection con = new OracleConnection(conn.getString());
        }
    }
}
