using System;
using System.Data.SqlClient;

namespace Reviso.DAL
{
    public class DBLogWorkingTime
    {
        string connString= DBConnection.getConnString();

        /// <summary>
        /// Saves the working time into the database.
        /// </summary>
        /// <param name="project">Project.</param>
        /// <param name="comment">Comment.</param>
        /// <param name="date">Date.</param>
        /// <param name="time">Time.</param>
        public void SaveWorkingTime(string project, string comment, string date, int time)
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
                sqlconn.Close();
            }

        }
    }
}
