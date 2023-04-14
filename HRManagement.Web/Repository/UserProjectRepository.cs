using HRManagement.Web.Context;
using HRManagement.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace HRManagement.Web.Repository
{
    public class UserProjectRepository : IUserProjectRepository
    {
        private readonly ApplicationContext _context;

        public UserProjectRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<UserProject> Add(UserProject o)
        {
            _context.UserProjects.Add(o);
            await _context.SaveChangesAsync();
            return o;
        }

        public async Task<int> Count()
        {
            return await _context.UserProjects.CountAsync();
        }

        public async Task Delete(UserProject o)
        {
            _context.UserProjects.Remove(o);
            await _context.SaveChangesAsync();
        }

        public X.PagedList.IPagedList<UserProject> GetAll(int? page = 1)
        {
            if (page != null && page < 1)
            {
                page = 1;
            }

            var pageSize = 5;
            var qry = _context.UserProjects.OrderByDescending(s => s.ProjectId).ToPagedList(page ?? 1, pageSize);
            return qry;
        }

        public async Task<List<UserProject>> GetAllRoot()
        {
            return await _context.UserProjects.ToListAsync();
        }

        public async Task<UserProject> GetById(string id)
        {
            return await _context.UserProjects.FirstOrDefaultAsync(x => x.UserId == id);
        }

        public async Task<UserProject> GetByIds(string userId, string projectId)
        {
            return await _context.UserProjects.FirstOrDefaultAsync(x => x.UserId == userId && x.ProjectId == projectId);
        }

        public async Task<UserProject> Update(UserProject o)
        {
            var e = _context.UserProjects.Update(o);
            await _context.SaveChangesAsync();
            return e.Entity;
        }
    }
}
