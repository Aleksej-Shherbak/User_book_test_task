using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Repos.Abstract
{
    public interface IRepository<T>
    {
        IQueryable<T> All { get; }

        Task SaveAsync(T entity);
        Task SaveAsync(List<T> entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<T> GetById(int id);
    }

}