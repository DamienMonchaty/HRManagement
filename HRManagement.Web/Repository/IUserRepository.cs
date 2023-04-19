using HRManagement.Web.Models;
using System.Threading.Tasks;

namespace HRManagement.Web.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> findByEmail(string email);    
    }
}
