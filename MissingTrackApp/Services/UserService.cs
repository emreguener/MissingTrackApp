using MissingTrackApp.Entities;
using MissingTrackApp.Interfaces;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace MissingTrackApp.Services
{
    public class UserService : IUserService
    {
        private readonly string _connectionString;
        private readonly ILogService _logService;
        public UserService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MissingTrack_DB"].ConnectionString;
            _logService = new LogService();
        }

        public User Authenticate(int userId, string password)
        {
            string hashedPassword = ComputeSha256Hash(password);

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT Id, Username FROM Users WHERE Id = @Id AND PasswordHash = @PasswordHash";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", userId);
                    cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var user = new User
                            {
                                Id = reader.GetInt32(0),
                                Username = reader.GetString(1)
                            };

                            _logService.LogLogin(user.Id); // giriş logu için
                            return user;
                        }
                    }
                }
            }

            return null;
        }

        private string ComputeSha256Hash(string rawData) // şifre hashleme için SHA256 kullanımı
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                    builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }
    }
}
