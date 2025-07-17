using MissingTrackApp.Entities;
using MissingTrackApp.Interfaces;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace MissingTrackApp.Services
{
    public class MissingPartService : IMissingPartService
    {
        private readonly string _connectionString;
        private readonly ILogService _logService;

        public MissingPartService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MissingTrack_DB"].ConnectionString;
            _logService = new LogService();
        }

        public void AddMissingParts(string serialStart16, string serialEndSuffix4, string missingCode8, int enteredByUserId)
        {
            // Validasyon
            if (serialStart16.Length != 16 || !serialStart16.StartsWith("3"))
                throw new ArgumentException("Seri numarası 16 haneli olmalı ve 3 ile başlamalıdır.");

            if (serialEndSuffix4.Length != 4)
                throw new ArgumentException("Seri bitişi 4 haneli olmalıdır.");

            if (missingCode8.Length != 8)
                throw new ArgumentException("Eksik parça kodu 8 haneli olmalıdır.");

            // Parçalama (arka planda hâlâ kullanılıyor)
            string modelCode = serialStart16.Substring(0, 8);
            string dateCode = serialStart16.Substring(8, 4);
            int startSerial = int.Parse(serialStart16.Substring(12, 4)); // seri numarasının başlangıç kısmı bu yüzden int
            int endSerial = int.Parse(serialEndSuffix4); // seri numarasının bitiş kısmı 

            if (endSerial < startSerial)
                throw new ArgumentException("Seri bitiş numarası başlangıçtan küçük olamaz.");

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                for (int i = startSerial; i <= endSerial; i++)
                {
                    string serialSuffix = i.ToString("D4");
                    string fullSerial = $"{modelCode}{dateCode}{serialSuffix}";

                    var cmd = new SqlCommand(@"
                        INSERT INTO MissingParts 
                        (FullSerial, MissingCode, EnteredByUserId, EntryDate)
                        VALUES 
                        (@FullSerial, @MissingCode, @UserId, @EntryDate)
                    ", conn);

                    cmd.Parameters.AddWithValue("@FullSerial", fullSerial);
                    cmd.Parameters.AddWithValue("@MissingCode", missingCode8);
                    cmd.Parameters.AddWithValue("@UserId", enteredByUserId);
                    cmd.Parameters.AddWithValue("@EntryDate", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }

                _logService.LogSave(enteredByUserId, serialStart16, serialEndSuffix4, missingCode8);
            }
        }
    }
}
