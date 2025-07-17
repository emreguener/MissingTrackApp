using System;
using System.Data.SqlClient;
using System.Configuration;
using MissingTrackApp.Interfaces;

namespace MissingTrackApp.Services
{
    public class LogService : ILogService
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["MissingTrack_DB"].ConnectionString;

        public void LogLogin(int userId)
        {
            InsertLog("User logged in", userId);
        }

        public void LogSave(int userId, string serialStart, string serialEnd, string missingCode)
        {
            string message = $"Saved missing part: Start={serialStart}, End={serialEnd}, Code={missingCode}";
            InsertLog(message, userId);
        }

        private void InsertLog(string action, int userId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Logs (Action, LogTime, UserId) VALUES (@action, @logTime, @userId)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@action", action);
                    cmd.Parameters.AddWithValue("@logTime", DateTime.Now);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
