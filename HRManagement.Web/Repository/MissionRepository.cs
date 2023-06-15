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
    public class MissionRepository : IMissionRepository
    {
        private readonly ApplicationContext _context;

        public MissionRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Mission> Add(Mission o)
        {
            _context.Missions.Add(o);
            await _context.SaveChangesAsync();
            return o;
        }

        public async Task Delete(Mission o)
        {
            _context.Missions.Remove(o);
            await _context.SaveChangesAsync();
        }

        public async Task<Mission> GetById(string id)
        {
            return await _context.Missions.Include(x => x.Project).OrderBy(x => x.Name).Include(x => x.User).AsSplitQuery().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Mission> Update(Mission o)
        {
            var p = _context.Missions.Update(o);
            await _context.SaveChangesAsync();
            return p.Entity;
        }

        public async Task<int> Count()
        {
            return await _context.Missions.CountAsync();
        }

        public IPagedList<Mission> GetAll(int? page = 1)
        {
            if (page != null && page < 1)
            {
                page = 1;
            }

            var pageSize = 5;
            var qry = _context.Missions.Include(x => x.Project).Include(x => x.User).Include(y => y.MissionSkills)
                      .ThenInclude(m => m.Skill).OrderByDescending(s => s.Id).ToPagedList(page ?? 1, pageSize);
            return qry;
        }

        public async Task<List<Mission>> GetAllRoot()
        {
            return await _context.Missions.ToListAsync();
        }

        public IPagedList<Mission> GetAllMissionsByUserId(string userId, int? page = 1)
        {
            if (page != null && page < 1)
            {
                page = 1;
            }

            var pageSize = 5;
            var qry = _context.Missions.Include(x => x.Project).Where(p => p.UserId == userId).OrderByDescending(s => s.Id).ToPagedList(page ?? 1, pageSize);
            return qry;
        }
    }
}
