using System;
using System.Data.SqlClient;

namespace Reviso.DAL
{
    public class DBLogWorkingTime
    {
        string connString= DBConnection.getConnString();

        public void SaveLog(string project, string comment, string date, int time)
        {
            SqlConnection sqlconn = new SqlConnection(connString);

            String query = "INSERT INTO dbo.Logs (project,comment,date,time) VALUES (@project,@comment,@date,@time)";

            using (SqlCommand command = new SqlCommand(query, sqlconn))
            {
                command.Parameters.AddWithValue("@project", project);
                command.Parameters.AddWithValue("@comment", comment);
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@time", time);

                sqlconn.Open();
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

        }
    }
}
