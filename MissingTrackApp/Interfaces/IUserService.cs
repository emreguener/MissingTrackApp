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
    }
}
