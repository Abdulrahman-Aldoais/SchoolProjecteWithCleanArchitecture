using Microsoft.EntityFrameworkCore.Storage;

namespace Core.Persistence.Repositories.Interface
{
    public interface IWriteRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity);
        TEntity Update(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        TEntity Delete(TEntity entity);
        Task<TEntity> DeleteAsync(TEntity entity);
        IDbContextTransaction BeginTransaction();
        void Commit();
        void RollBack();
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task CommitAsync();
        Task RollBackAsync();


    }
}
