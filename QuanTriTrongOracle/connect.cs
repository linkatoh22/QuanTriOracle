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
        static string conString = "";

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

        public void setConnect(string username, string password)
        {
            conString = @"DATA SOURCE =" + PATH + "; USER ID=" + username + ";PASSWORD=" + password+";DBA PRIVILEGE=SYSDBA";
        }
    }
}
