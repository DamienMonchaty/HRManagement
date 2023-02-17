using HRManagement.Business.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Business.Services
{
    public interface ILoginService
    {
        Task<bool> AuthenticateUser(string username, string passcode);
    }
}
