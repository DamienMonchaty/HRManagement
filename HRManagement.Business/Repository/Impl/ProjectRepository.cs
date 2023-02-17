using HRManagement.Business.Context;
using HRManagement.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Business.Repository.Impl
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ModelDbContext _context;

        public ProjectRepository()
        {
            _context = new ModelDbContext();
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
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> GetById(int id)
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

       
    }
}
