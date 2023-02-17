using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Business.Repository
{
    public interface IEnterpriseRepository
    {
        Task<int> GetRhEmployeeIdByEmployeeId(int EmployeeId);
    }
}
