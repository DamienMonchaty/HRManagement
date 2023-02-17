using BCrypt.Net;
using HRManagement.Business.Context;
using HRManagement.Common.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace HRManagement.Business.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ModelDbContext _context;

        public UserRepository()
        {
            _context = new ModelDbContext();
        }

        public async Task<User> Add(User o)
        {
            User uToSave = new User
            {
                UserName = o.UserName,
                FirstName = o.FirstName,
                LastName = o.LastName,
                Email = o.Email,
                Password = BC.HashPassword(o.Password),
                Sexe = o.Sexe,
                BirthDate = o.BirthDate,
                BirthPlace = o.BirthPlace,
                BirthCountry = o.BirthCountry,
                Nationality = o.Nationality,
                Address = o.Address,
                Active = o.Active
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

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id.ToString());
        }

        public async Task<User> GetByUserNameAndPassword(string userName, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName && x.Password == password);
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
