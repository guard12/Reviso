﻿using System;
using System.Data.SqlClient;
using Reviso.Model;
using System.Collections.Generic;

namespace Reviso.DAL
{
    public class DBGetWorkingTime
    {
        string connString = DBConnection.getConnString();

        public List<TimeLog> GetAllLogs()
        {
            List<TimeLog> loglist = new List<TimeLog>();
            SqlConnection sqlconn = new SqlConnection(connString);

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
    }
}
