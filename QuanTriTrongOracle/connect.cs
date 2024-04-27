using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace QuanTriTrongOracle
{
    internal class connect
    {
        private static OracleConnection connection;
        string PATH = "localhost:1521/XE;";
        string PATH_PDB = "localhost:1521/QLDLNOIBO;";
        static string conString = "";
        private string role;
        private string username;

        public static OracleConnection getConnection()
        {
            {
                // Kiểm tra nếu kết nối chưa được tạo hoặc đã đóng
                if (connection == null)
                {
                    // Khởi tạo kết nối mới
                    connection = new OracleConnection(conString);
                }

                return connection;
            }
        }

        public string getString()
        {
            return conString;
        }
        public string getusername()
        {
            return username;
        }

        public void setConnect(string username, string password,string type)
        {
            if (type == "PH1")
            {
                //conString = @"DATA SOURCE =" + PATH + "; USER ID=" + username + ";PASSWORD=" + password+";DBA PRIVILEGE=SYSDBA";
                conString = @"DATA SOURCE =" + PATH + "; USER ID=" + username + ";PASSWORD=" + password + ";DBA PRIVILEGE=SYSDBA";

            }
            else if(type == "PH2")
            {
                conString = @"DATA SOURCE =" + PATH_PDB + "; USER ID=" + username + ";PASSWORD=" + password;
                this.username = username;
            }    
        }
    }
}
