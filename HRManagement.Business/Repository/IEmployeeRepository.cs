using HRManagement.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Business.Repository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task SaveToElasticsearchEmployee(Employee employee);
        Task<IEnumerable<Employee>> GetElasticsearchEmployee(string term);
        IEnumerable<Employee> QueryString(string term);
    }
}
