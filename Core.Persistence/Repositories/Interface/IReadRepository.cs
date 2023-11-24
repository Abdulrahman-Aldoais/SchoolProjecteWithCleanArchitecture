using School.Domain.Entities;
using System.Linq.Expressions;

namespace Core.Repositories.Interface
{
    public interface IReadRepository<TEntity> where TEntity : BaseModel
    {
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate = null);
        TEntity Get(Expression<Func<TEntity, bool>> predicate = null);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate = null);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null);
        Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate = null);
        Task<int> CountAsync();
        IQueryable<TEntity> GetTableNoTracking();
        IQueryable<TEntity> GetTableAsTracking();

    }
}
