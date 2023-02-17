using HRManagement.Business.Context;
using HRManagement.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Business.Repository
{
    public class AppointmentRepository : IRepository<Appointment>
    {
        private readonly ModelDbContext _context;

        public AppointmentRepository()
        {
            _context = new ModelDbContext();
        }

        public async Task<Appointment> Add(Appointment o)
        {
            _context.Appointments.Add(o); // On ajoute en db
            await _context.SaveChangesAsync(); // On commit les changements
            return o;
        }

        public async Task Delete(Appointment o)
        {
            _context.Appointments.Remove(o);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Appointment>> GetAll()
        {
            return await _context.Appointments.ToListAsync();
        }

        public async Task<Appointment> GetById(int id)
        {
            return await _context.Appointments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Appointment> Update(Appointment o)
        {
            var appointment = _context.Appointments.Update(o);
            await _context.SaveChangesAsync();
            return appointment.Entity;
        }

        public async Task<int> Count()
        {
            return await _context.Appointments.CountAsync();
        }
    }
}
