using School.Domain.Entities;
using System.Linq.Expressions;

namespace Core.Repositories.Interface
{
    public interface IReadRepository<T> where T : BaseModel
    {
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate = null);
        T Get(Expression<Func<T, bool>> predicate = null);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate = null);
        IQueryable<T> GetAllFiles(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null);
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> predicate = null);
        Task<int> CountAsync();

    }
}
