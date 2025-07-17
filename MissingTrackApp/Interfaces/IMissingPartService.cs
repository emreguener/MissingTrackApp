using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingTrackApp.Interfaces
{
    public interface IMissingPartService
    {
        void AddMissingParts(string serialStart16, string serialEndSuffix4, string missingCode8, int enteredByUserId);
    }
}

