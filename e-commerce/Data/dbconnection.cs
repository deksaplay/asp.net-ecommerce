using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System.Data.Common;

namespace e_commerce.Data
{
    public class dbconnection
    {
        string connnstr = "";
        SqlConnection dbconn = null;
        public dbconnection(string connstring) { 
            this.connnstr = connstring;
        }
        public SqlConnection GetConnection()
        {
            if(this.dbconn == null)
            {
                dbconn = new SqlConnection(this.connnstr);
                dbconn.Open();
            }
            else if(this.dbconn.State == System.Data.ConnectionState.Closed) {
                this.dbconn.Open();
            }
            return dbconn;
        }

    }
}
