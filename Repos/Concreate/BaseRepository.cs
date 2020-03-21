using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;
using Domains.Abstract;
using Microsoft.EntityFrameworkCore;
using Repos.Abstract;
using X.PagedList;

namespace Repos.Concreate
{
    public class BaseRepository<T, C> : IRepository<T>
        where T : class, IDomain<int>
        where C : DbContext
    {
        protected C DataContext;
        private readonly DbSet<T> _dbset;

        public BaseRepository(C context)
        {
            DataContext = context;
            _dbset = context.Set<T>();
        }

        public virtual IQueryable<T> All => _dbset;
        
        public virtual async Task SaveAsync(T entity)
        {
            await _dbset.AddAsync(entity);
            await DataContext.SaveChangesAsync();
        }

        public async Task SaveAsync(List<T> entity)
        {
            await _dbset.AddRangeAsync(entity);
            await DataContext.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _dbset.Attach(entity).State = EntityState.Modified;
            _dbset.Update(entity);
            await DataContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var dbEntity =  await _dbset.FindAsync(id);

            if (dbEntity != null)
            {
                _dbset.Remove(dbEntity);
                await DataContext.SaveChangesAsync();
            }
        }

        public virtual async Task<T> GetById(int id)
        {
            return await _dbset.FindAsync(id);
        }
        
    }
}