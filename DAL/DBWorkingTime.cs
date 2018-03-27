using System;
using System.Data.SqlClient;

namespace Reviso.DAL
{
    public class DBWorkingTime
    {
        private string connectionString = "Data Source = localhost;User ID=sa;Password=2Y59FUr84;Initial Catalog=Reviso;integrated security=false;";

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
                    Console.WriteLine(e);
                }
            }
            
        }

        public void Test(){
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
