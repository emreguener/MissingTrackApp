using MissingTrackApp.Entities;
using MissingTrackApp.Interfaces;
using System.Collections.Generic;
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
                string query = "SELECT Id, Username, Role FROM Users WHERE Id = @Id AND PasswordHash = @PasswordHash";

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
                                Username = reader.GetString(1),
                                Role = reader.GetString(2)
                            };

                            _logService.LogLogin(user.Id); // giriş logu için
                            return user;
                        }
                    }
                }
            }

            return null;
        }

        public void UpdatePassword(int userId, string newPassword)
        {
            string hash = ComputeSha256Hash(newPassword);

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "UPDATE Users SET PasswordHash = @PasswordHash WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PasswordHash", hash);
                    cmd.Parameters.AddWithValue("@Id", userId);
                    cmd.ExecuteNonQuery();
                }
            }

            //_logService.Log(userId, "Şifre güncellendi");
        }

        public int? Register(User user, string plainPassword)
        {
            string hashedPassword = ComputeSha256Hash(plainPassword);

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"
            INSERT INTO Users (Username, PasswordHash, Role) 
            OUTPUT INSERTED.Id 
            VALUES (@Username, @PasswordHash, @Role)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                    cmd.Parameters.AddWithValue("@Role", user.Role);

                    object insertedId = cmd.ExecuteScalar();
                    if (insertedId != null && int.TryParse(insertedId.ToString(), out int newId))
                        return newId;
                    else
                        return null;
                }
            }
        }


        public bool ChangePassword(int userId, string oldPassword, string newPassword)
        {
            string oldHash = ComputeSha256Hash(oldPassword);
            string newHash = ComputeSha256Hash(newPassword);

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "UPDATE Users SET PasswordHash = @NewHash WHERE Id = @Id AND PasswordHash = @OldHash";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NewHash", newHash);
                    cmd.Parameters.AddWithValue("@Id", userId);
                    cmd.Parameters.AddWithValue("@OldHash", oldHash);

                    return cmd.ExecuteNonQuery() == 1;
                }
            }
        }

        public bool ChangePasswordAsAdmin(int targetUserId, string newPassword)
        {
            string newHash = ComputeSha256Hash(newPassword);

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "UPDATE Users SET PasswordHash = @NewHash WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NewHash", newHash);
                    cmd.Parameters.AddWithValue("@Id", targetUserId);
                    return cmd.ExecuteNonQuery() == 1;
                }
            }
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT Id, Username, Role FROM Users";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            Id = reader.GetInt32(0),
                            Username = reader.GetString(1),
                            Role = reader.GetString(2)
                        });
                    }
                }
            }

            return users;
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
