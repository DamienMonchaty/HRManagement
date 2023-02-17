using HRManagement.Business.Context;
using HRManagement.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Business.Repository
{
    public class EmployeeProjectRepository : IRepository<EmployeeProject>
    {
        private readonly ModelDbContext _context;

        public EmployeeProjectRepository()
        {
            _context = new ModelDbContext();
        }

        public async Task<EmployeeProject> Add(EmployeeProject o)
        {
            _context.EmployeeProjects.Add(o);
            await _context.SaveChangesAsync();
            return o;
        }

        public async Task<int> Count()
        {
            return await _context.EmployeeProjects.CountAsync();
        }

        public async Task Delete(EmployeeProject o)
        {
            _context.EmployeeProjects.Remove(o);
            await _context.SaveChangesAsync();
        }

        public async Task<List<EmployeeProject>> GetAll()
        {
            return await _context.EmployeeProjects.ToListAsync();
        }

        public async Task<EmployeeProject> GetById(int id)
        {
            return await _context.EmployeeProjects.FirstOrDefaultAsync(x => x.EmployeeId == id);
        }

        public async Task<EmployeeProject> Update(EmployeeProject o)
        {
            var e = _context.EmployeeProjects.Update(o);
            await _context.SaveChangesAsync();
            return e.Entity;
        }
    }
}
