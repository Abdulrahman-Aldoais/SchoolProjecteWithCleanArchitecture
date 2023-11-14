using System.Linq.Expressions;

namespace Core.Repositories.Interface
{
    public interface IReadForUserRepository<TEntity> where TEntity : class
    {
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate = null);
        TEntity Get(Expression<Func<TEntity, bool>> predicate = null);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate = null);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null);
        Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate = null);
        Task<int> CountAsync();

    }
}
