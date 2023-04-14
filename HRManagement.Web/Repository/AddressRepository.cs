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
    public class AddressRepository : IRepository<Address>
    {
        private readonly ApplicationContext _context;

        public AddressRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Address> Add(Address o)
        {
            _context.Addresses.Add(o);
            await _context.SaveChangesAsync();
            return o;
        }

        public async Task Delete(Address o)
        {
            _context.Addresses.Remove(o);
            await _context.SaveChangesAsync();
        }

        public async Task<Address> GetById(string id)
        {
            return await _context.Addresses.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Address> Update(Address o)
        {
            var address = _context.Addresses.Update(o);
            await _context.SaveChangesAsync();
            return address.Entity;
        }

        public async Task<int> Count()
        {
            return await _context.Addresses.CountAsync();
        }

        public IPagedList<Address> GetAll(int? page = 1)
        {
            if (page != null && page < 1)
            {
                page = 1;
            }

            var pageSize = 5;
            var qry = _context.Addresses.OrderByDescending(s => s.Id).ToPagedList(page ?? 1, pageSize);
            return qry;
        }

        public async Task<List<Address>> GetAllRoot()
        {
            return await _context.Addresses.ToListAsync();
        }
    }
}
