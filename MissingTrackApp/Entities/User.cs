namespace MissingTrackApp.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; } // admin / operator
        public string PasswordHash { get; set; }

        public override string ToString()
        {
            return $"{Username} (Id: {Id}, Rol: {Role})";
        }
    }
}
