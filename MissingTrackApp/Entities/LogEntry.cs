using System;
// loglama için gerekebilir
namespace MissingTrackApp.Entities
{
    public class LogEntry
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public int UserId { get; set; }
        public DateTime LogTime { get; set; }
    }
}
