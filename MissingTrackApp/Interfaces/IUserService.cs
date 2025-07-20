using MissingTrackApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingTrackApp.Interfaces
{
    public interface IUserService
    {
        User Authenticate(int userId, string password);

        int? Register(User user, string plainPassword);
        // bool yerine int? döner: kullanıcı başarıyla eklenirse Id, aksi halde null

        List<User> GetAllUsers(); // admin için combobox'a kullanıcı doldurmak için

        bool ChangePassword(int userId, string oldPassword, string newPassword); // Kullanıcı kendi şifresini değiştirsin

        bool ChangePasswordAsAdmin(int targetUserId, string newPassword); // Admin başka birinin şifresini değiştirsin


    }
}
