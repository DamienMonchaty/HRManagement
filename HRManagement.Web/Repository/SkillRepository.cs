using HRManagement.Web.Context;
using HRManagement.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace HRManagement.Web.Repository
{
    public class SkillRepository : IRepository<Skill>
    {
        private readonly ApplicationContext _context;

        public SkillRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Skill> Add(Skill o)
        {
            _context.Skills.Add(o);
            await _context.SaveChangesAsync();
            return o;
        }

        public async Task Delete(Skill o)
        {
            _context.Skills.Remove(o);
            await _context.SaveChangesAsync();
        }

        public async Task<Skill> GetById(string id)
        {
            return await _context.Skills.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Skill> Update(Skill o)
        {
            var address = _context.Skills.Update(o);
            await _context.SaveChangesAsync();
            return address.Entity;
        }

        public async Task<int> Count()
        {
            return await _context.Addresses.CountAsync();
        }

        public IPagedList<Skill> GetAll(int? page = 1)
        {
            if (page != null && page < 1)
            {
                page = 1;
            }

            var pageSize = 5;
            var qry = _context.Skills.OrderByDescending(s => s.Id).ToPagedList(page ?? 1, pageSize);
            return qry;
        }

        public async Task<List<Skill>> GetAllRoot()
        {
            return await _context.Skills.ToListAsync();
        }
    }
}
