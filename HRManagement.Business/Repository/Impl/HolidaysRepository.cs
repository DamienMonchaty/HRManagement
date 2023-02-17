using HRManagement.Business.Context;
using HRManagement.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Business.Repository
{
    public class HolidaysRepository : IRepository<Holidays>
    {
        private readonly ModelDbContext _context;

        public HolidaysRepository()
        {
            _context = new ModelDbContext();
        }

        public async Task<Holidays> Add(Holidays o)
        {
            _context.Holidays.Add(o); // On ajoute en db
            await _context.SaveChangesAsync(); // On commit les changements
            return o;
        }

        public async Task Delete(Holidays o)
        {
            _context.Holidays.Remove(o);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Holidays>> GetAll()
        {
            return await _context.Holidays.ToListAsync();
        }

        public async Task<Holidays> GetById(int id)
        {
            return await _context.Holidays.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Holidays> Update(Holidays o)
        {
            var holiday = _context.Holidays.Update(o);
            await _context.SaveChangesAsync();
            return holiday.Entity;
        }

        public async Task<int> Count()
        {
            return await _context.Holidays.CountAsync();
        }
    }
}
