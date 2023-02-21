using HRManagement.Web.Context;
using HRManagement.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<List<Project>> GetAll()
        {
            return await _context.Projects.Include(x => x.Client).ToListAsync();
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
            return _context.Projects
               .Where(p => p.Id == projectId)
               .SelectMany(p => p.UserProjects)
               .Select(pc => pc.User).ToList();
        }
    }
}
