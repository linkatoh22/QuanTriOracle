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
    public partial class GV_XemThongTin : UserControl
    {
        OracleConnection con = new OracleConnection(new connect().getString());

        public GV_XemThongTin()
        {
            InitializeComponent();
            updateGrid();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void updateGrid()
        {
            con.Open();
            OracleCommand getEmps = con.CreateCommand();
            getEmps.CommandText = "SELECT * FROM ADMINQL.NHANSU";
            getEmps.CommandType = CommandType.Text;
            OracleDataReader empDR = getEmps.ExecuteReader();
            DataTable empDT = new DataTable();
            empDT.Load(empDR);
            dataGridView1.DataSource = empDT;
            con.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Update_NhanSu_Click(object sender, EventArgs e)
        {
            con.Open();
            OracleCommand cmd = new OracleCommand("ADMINQL.PROC_UPD_SDT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("SDT", "varchar2").Value = textBox1.Text;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Update số điện thoại thành công");
            con.Close();
            updateGrid();
        }
    }
}
