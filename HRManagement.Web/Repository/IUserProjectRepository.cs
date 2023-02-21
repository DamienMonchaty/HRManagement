using HRManagement.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.Web.Repository
{
    public interface IUserProjectRepository : IRepository<UserProject>
    {
        Task<UserProject> GetByIds(string userId, string projectId);
    }
}
