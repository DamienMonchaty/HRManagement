using BCrypt.Net;
using HRManagement.Web.Context;
using HRManagement.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


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

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.Include("Address").ToListAsync();
        }

        public async Task<User> GetById(string id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
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
    }
}
