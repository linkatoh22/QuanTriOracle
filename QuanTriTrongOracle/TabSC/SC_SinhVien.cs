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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanTriTrongOracle.TabSC
{
    public partial class SC_SinhVien : UserControl
    {
        OracleConnection con = new OracleConnection(new connect().getString());
        public SC_SinhVien()
        {
            InitializeComponent();
            updateGrid();
        }
        private void updateGrid()
        {
            con.Open();
            OracleCommand getEmps = con.CreateCommand();
            getEmps.CommandText = "SELECT * FROM ADMINQL.SINHVIEN";
            getEmps.CommandType = CommandType.Text;
            OracleDataReader empDR = getEmps.ExecuteReader();
            DataTable empDT = new DataTable();
            empDT.Load(empDR);
            dataGridView1.DataSource = empDT;
            binding();
            con.Close();
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void binding ()
        {
            phone_SC.DataBindings.Clear();
            phone_SC.DataBindings.Add("Text", dataGridView1.DataSource, "DIENTHOAI");
            diachi_SC.DataBindings.Clear();
            diachi_SC.DataBindings.Add("Text", dataGridView1.DataSource, "DIACHI");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            OracleCommand cmd = new OracleCommand("ADMINQL.PROC_UPDATESINHVIEN", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("DT", "varchar2").Value = phone_SC.Text;
            cmd.Parameters.Add("DCHI", "varchar2").Value = diachi_SC.Text;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Update thông tin thành công");
            con.Close();
            updateGrid();
        }
    }
}
