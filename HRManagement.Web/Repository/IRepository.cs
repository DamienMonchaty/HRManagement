using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace HRManagement.Web.Repository
{
    public interface IRepository<T> where T : class, new()
    {
        Task<List<T>> GetAllRoot();
        IPagedList<T> GetAll(int? page = 1);
        Task<T> Add(T o);
        Task<T> GetById(string id);
        Task<T> Update(T o);
        Task Delete(T o);
        Task<int> Count();
    }
}
