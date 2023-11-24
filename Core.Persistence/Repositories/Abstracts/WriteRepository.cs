using Core.Persistence.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Core.Persistence.Repositories.Abstracts
{
    public class WriteRepository<TEntity, TContext> : IWriteRepository<TEntity>

        where TEntity : class

        where TContext : DbContext
    {
        protected TContext Context;
        public WriteRepository(TContext context)
        {
            Context = context;
        }



        public TEntity Add(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            Context.SaveChanges();
            return entity;
        }



        public async Task<TEntity> AddAsync(TEntity entity)
        {
            try
            {
                Context.Entry(entity).State = EntityState.Added;
                await Context.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var entry = ex.Entries.Single();
                await entry.ReloadAsync();
                entry.CurrentValues.SetValues(entry.OriginalValues);
                await Context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TEntity Delete(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            Context.SaveChanges();
            return entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            await Context.SaveChangesAsync();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entity;
        }

        public IDbContextTransaction BeginTransaction()
        {
            return Context.Database.BeginTransaction();
        }

        public void Commit()
        {
            Context.Database.CommitTransaction();

        }

        public void RollBack()
        {
            Context.Database.RollbackTransaction();
        }
        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await Context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            await Context.Database.CommitTransactionAsync();
        }

        public async Task RollBackAsync()
        {
            await Context.Database.RollbackTransactionAsync();
        }


    }
}
