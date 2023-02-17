using HRManagement.Business.Context;
using HRManagement.Business.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace HRManagement.Business.Services.Impl
{
    public class LoginService : ILoginService
    {
        private readonly ModelDbContext _context;

        public LoginService()
        {
            _context = new ModelDbContext();
        }

        public async Task<bool> AuthenticateUser(string username, string passcode)
        {
            var u = await _context.Users.FirstOrDefaultAsync(authUser => authUser.UserName == username);
            if(u != null && BC.Verify(passcode, u.Password))
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
