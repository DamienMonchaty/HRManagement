using HRManagement.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Business.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByUserNameAndPassword(string userName, string password);
        Task<User> GetByUserName(string userName);
        Task<string> GetEmailByUserId(int id);
    }
}
