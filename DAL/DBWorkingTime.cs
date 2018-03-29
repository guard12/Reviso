using System;
using System.Data.SqlClient;
using Reviso.Model;
using System.Collections.Generic;

namespace Reviso.DAL
{
    public class DBWorkingTime
    {
        private string connectionString = "Data Source = localhost;User ID=sa;Password=pT20pPnj;Initial Catalog=Reviso;integrated security=false;";

        public void SaveLog(string project, string comment, string date, int time)
        {
            SqlConnection sqlconn = new SqlConnection(connectionString);

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
                catch(Exception e)
                {
                    throw e;
                }
            }
            
        }

        public List<TimeLog> GetAllLogs()
        {
            List<TimeLog> loglist = new List<TimeLog>();
            SqlConnection sqlconn = new SqlConnection(connectionString);

            using (sqlconn)
            {
                SqlCommand command = new SqlCommand(
                  "SELECT * FROM dbo.Logs",
                    sqlconn);
                sqlconn.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TimeLog tl = new TimeLog();
                        tl.id = Convert.ToInt32(reader["LogID"]);
                        tl.Project = reader["Project"].ToString();
                        tl.Comment = reader["Comment"].ToString();
                        tl.Date = reader["Date"].ToString();
                        tl.Time = Convert.ToInt32(reader["Time"]);
                        loglist.Add(tl);
                    }
                }
                reader.Close();
                return loglist;
            }
        }

        public void TestConnection(){
            SqlConnection sqlconn = new SqlConnection(connectionString);
            try
            {
                sqlconn.Open();
            }
            catch(Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }
}
