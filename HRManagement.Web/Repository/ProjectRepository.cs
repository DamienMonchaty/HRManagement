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
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationContext _context;

        public ProjectRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Project> Add(Project o)
        {
            _context.Projects.Add(o);
            await _context.SaveChangesAsync();
            return o;
        }

        public async Task Delete(Project o)
        {
            _context.Projects.Remove(o);
            await _context.SaveChangesAsync();
        }

        public async Task<Project> GetById(string id)
        {
            return await _context.Projects.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Project> Update(Project o)
        {
            var p = _context.Projects.Update(o);
            await _context.SaveChangesAsync();
            return p.Entity;
        }

        public async Task<int> Count()
        {
            return await _context.Projects.CountAsync();
        }

        public async Task<List<User>> GetAllUsersByProject(string projectId)
        {
            return await _context.Projects
               .Where(p => p.Id == projectId)
               .SelectMany(p => p.UserProjects)
               .Select(pc => new User {
                   Id = pc.UserId,
                   UserName = pc.User.UserName
               }).ToListAsync();
        }

        public IPagedList<Project> GetAll(int? page = 1)
        {
            if (page != null && page < 1)
            {
                page = 1;
            }

            var pageSize = 5;
            var qry = _context.Projects.Include(c => c.Client).Include(c => c.Missios).OrderByDescending(s => s.Id).ToPagedList(page ?? 1, pageSize);
            return qry;
        }

        public async Task<List<Project>> GetAllRoot()
        {
            return await _context.Projects.ToListAsync();
        }

        public IPagedList<Project> GetAllProjectsByUserId(string userId, int? page = 1)
        {
            if (page != null && page < 1)
            {
                page = 1;
            }

            var pageSize = 5;
            var qry = _context.Projects.SelectMany(p => p.UserProjects).Where(p => p.UserId == userId).Select(p => p.Project).OrderByDescending(s => s).ToPagedList(page ?? 1, pageSize);
            return qry;
        }
    }
}
