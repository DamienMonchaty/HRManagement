using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.Web.Services
{
    public interface ILoginService
    {
        Task<bool> AuthenticateUser(string username, string passcode);
    }
}
