using Core.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.Persistence.Repositories.Abstracts
{
    public class ReadForUserRepository<TEntity, TContext> : IReadForUserRepository<TEntity>
      where TEntity : class
      where TContext : DbContext
    {
        protected TContext Context;

        public ReadForUserRepository(TContext context)
        {
            Context = context;
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            return await Context.Set<TEntity>().AnyAsync(predicate);
        }

        public async Task<int> CountAsync()
        {
            return await Context.Set<TEntity>().CountAsync();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate = null)
        {
            return Context.Set<TEntity>().AsNoTracking().FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
                return Context.Set<TEntity>().AsQueryable();
            else
                return Context.Set<TEntity>().Where(predicate);
        }
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            return await Context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
                return Context.Set<TEntity>().ToList();
            else
                return await Context.Set<TEntity>().Where(predicate).ToListAsync();
        }


    }
}
