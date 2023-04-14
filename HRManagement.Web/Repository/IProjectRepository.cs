using HRManagement.Web.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace HRManagement.Web.Repository
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<List<User>> GetAllUsersByProject(string projectId);
        IPagedList<Project> GetAllProjectsByUserId(string userId, int? page = 1);
    }
}
