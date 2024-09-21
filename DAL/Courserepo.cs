using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AzureWebApplication1.DAL
{
    public class Courserepo
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["AzureSqlDbConnection"].ConnectionString;

        public List<Course> GetAllData()
        {
            var data = new List<Course>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT CourseID, CourseName, Rating FROM Course";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    data.Add(new Course
                    {
                        CourseID = (int)reader["CourseID"],
                        CourseName = reader["CourseName"].ToString(),
                        Rating = Convert.ToDecimal(reader["Rating"])
                    });
                }
            }

            return data;
        }
    }
}