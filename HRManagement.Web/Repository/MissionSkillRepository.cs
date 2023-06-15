using HRManagement.Web.Context;
using HRManagement.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace HRManagement.Web.Repository
{
    public class MissionSkillRepository : IRepository<MissionSkill>
    {
        private readonly ApplicationContext _context;

        public MissionSkillRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<MissionSkill> Add(MissionSkill o)
        {
            _context.MissionSkills.Add(o);
            await _context.SaveChangesAsync();
            return o;
        }

        public async Task Delete(MissionSkill o)
        {
            _context.MissionSkills.Remove(o);
            await _context.SaveChangesAsync();
        }

        public async Task<MissionSkill> GetById(string id)
        {
            return await _context.MissionSkills.FirstOrDefaultAsync(x => x.MissionId == id);
        }

        public async Task<MissionSkill> Update(MissionSkill o)
        {
            var p = _context.MissionSkills.Update(o);
            await _context.SaveChangesAsync();
            return p.Entity;
        }

        public async Task<int> Count()
        {
            return await _context.Clients.CountAsync();
        }

        public IPagedList<MissionSkill> GetAll(int? page = 1)
        {
            if (page != null && page < 1)
            {
                page = 1;
            }

            var pageSize = 5;
            var qry = _context.MissionSkills.OrderByDescending(s => s.MissionId).ToPagedList(page ?? 1, pageSize);
            return qry;
        }

        public async Task<List<MissionSkill>> GetAllRoot()
        {
            return await _context.MissionSkills.ToListAsync();
        }
    }
}
