using System;
using System.Data.SqlClient;

namespace Reviso.DAL
{
    public class DBConnection
    {
        public static string getConnString()
        {
            return "Data Source = localhost;User ID=sa;Password=pT20pPnj;Initial Catalog=Reviso;integrated security=false;";
        }

        /// <summary>
        /// Test Connection to database
        /// </summary>
        public void TestConnection()
        {
            SqlConnection sqlconn = new SqlConnection(getConnString());
            try
            {
                sqlconn.Open();
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }
}
