using BCrypt.Net;
using HRManagement.Web.Context;
using HRManagement.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace HRManagement.Web.Repository
{
    public class UserRepository : IRepository<User>
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<User> Add(User o)
        {
            User uToSave = new User
            {
                UserName = o.UserName,
                FirstName = o.FirstName,
                LastName = o.LastName,
                Email = o.Email,
                BirthDate = o.BirthDate,
                BirthPlace = o.BirthPlace,
                BirthCountry = o.BirthCountry,
                Nationality = o.Nationality,
                Address = o.Address,
            };
            _context.Users.Add(uToSave); 
            await _context.SaveChangesAsync();
            return o;
        }

        public async Task Delete(User o)
        {
            _context.Users.Remove(o);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetById(string id)
        {
            return await _context.Users.Include(x => x.Address).OrderBy(x => x.FirstName).Include(x => x.Missions).Include(y => y.Diplomas).Include(y => y.Schools).AsSplitQuery().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetByUserName(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
        }

        public async Task<User> Update(User o)
        {
            var user = _context.Users.Update(o);
            await _context.SaveChangesAsync();
            return user.Entity;
        }

        public async Task<string> GetEmailByUserId(int id)
        {
            var u = await _context.Users.FirstOrDefaultAsync(x => x.Id == id.ToString());
            return u.Email;
        }

        public async Task<int> Count()
        {
            return await _context.Users.CountAsync();
        }

        public IPagedList<User> GetAll(int? page = 1)
        {
            if (page != null && page < 1)
            {
                page = 1;
            }

            var pageSize = 5;
            var qry = _context.Users.Include(x => x.UserProjects).ThenInclude(y => y.Project).Include(x => x.Missions).OrderByDescending(s => s.Id).ToPagedList(page ?? 1, pageSize);
            return qry;
        }

        public async Task<List<User>> GetAllRoot()
        {
            return await _context.Users.Include(x => x.UserProjects).ThenInclude(y => y.Project).Include(x => x.Missions).ToListAsync();
        }
    }
}
