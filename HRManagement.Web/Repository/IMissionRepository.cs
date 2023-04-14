using HRManagement.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace HRManagement.Web.Repository
{
    public interface IMissionRepository : IRepository<Mission>
    {
        IPagedList<Mission> GetAllMissionsByUserId(string userId, int? page = 1);
    }
}
