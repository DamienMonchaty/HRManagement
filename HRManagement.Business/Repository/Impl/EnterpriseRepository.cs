using HRManagement.Business.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Business.Repository.Impl
{
    public class EnterpriseRepository : IEnterpriseRepository
    {
        private readonly ModelDbContext _context;

        public EnterpriseRepository()
        {
            _context = new ModelDbContext();
        }

        public async Task<int> GetRhEmployeeIdByEmployeeId(int EmployeeId)
        {
            var a = await _context.Enterprises.FirstOrDefaultAsync(x => x.EmployeeId == EmployeeId);

            return (int)(a.RhEmployeeId);
        }
    }
}
