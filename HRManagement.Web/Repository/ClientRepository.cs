﻿using HRManagement.Web.Context;
using HRManagement.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.Web.Repository
{
    public class ClientRepository : IRepository<Client>
    {
        private readonly ApplicationContext _context;

        public ClientRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Client> Add(Client o)
        {
            _context.Clients.Add(o);
            await _context.SaveChangesAsync();
            return o;
        }

        public async Task Delete(Client o)
        {
            _context.Clients.Remove(o);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Client>> GetAll()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetById(string id)
        {
            return await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Client> Update(Client o)
        {
            var p = _context.Clients.Update(o);
            await _context.SaveChangesAsync();
            return p.Entity;
        }

        public async Task<int> Count()
        {
            return await _context.Projects.CountAsync();
        }
    }
}
