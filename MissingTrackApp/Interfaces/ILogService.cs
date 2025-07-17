using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingTrackApp.Interfaces
{
    public interface ILogService
    {
        void LogLogin(int userId);

        void LogSave(int userId, string serialStart, string serialEnd, string missingCode);
    }

}
