using HRManagement.Web.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace HRManagement.Web.Services
{
    public class LoginService : ILoginService
    {
        private readonly ApplicationContext _context;

        public LoginService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> AuthenticateUser(string username, string passcode)
        {
            var u = await _context.Users.FirstOrDefaultAsync(authUser => authUser.UserName == username);
            if (u != null && BC.Verify(passcode, u.PasswordHash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
