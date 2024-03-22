using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanTriTrongOracle
{
    internal class connect
    {
        string PATH = "localhost:1521/XE;";
        static string conString = "";

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
}
