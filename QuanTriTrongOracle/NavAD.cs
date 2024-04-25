using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;

namespace QuanTriTrongOracle
{
    public partial class NavAD : Form
    {
        OracleConnection con = new OracleConnection(new connect().getString());
        DataTable dtAudit;
        public NavAD()
        {
            InitializeComponent();

        }

        private void Load(String sql, int column)
        {
            //dtAudit = Functions.GetDataToTable(sql);
            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = con;

            OracleDataAdapter adapter = new OracleDataAdapter(command);
            dtAudit = new DataTable(); //create a new table
            adapter.Fill(dtAudit);

            dgv.DataSource = dtAudit;

            int width = 150;
            if (column == 3)
            {
                width = 250;
            }
            for (int i = 0; i < column; i++)
            {
                dgv.Columns[i].Width = width;

            }
        }

        private void btn_xem1_Click(object sender, EventArgs e)
        {
            if (cbox_1.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn Fine Grained Audit", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            String s = cbox_1.Text.Trim();
            string[] words = s.Split('(');

            string[] words2 = words[1].Split(')');
            String s2 = words2[0];
            Load("SELECT DBUID, LSQLTEXT, NTIMESTAMP# FROM SYS.FGA_LOG$ WHERE LSQLTEXT LIKE '%" + words2[0] + "%'", 3);
        }

        private void btn_xem2_Click(object sender, EventArgs e)
        {
            if (cbox_2.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn Standard Audit", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Load("SELECT extended_timestamp, username, owner, obj_name, action_name, sql_text FROM dba_audit_trail " +
                "WHERE OBJ_NAME = '" + cbox_2.Text.Trim() + "' ", 5);
        }
    }
}
