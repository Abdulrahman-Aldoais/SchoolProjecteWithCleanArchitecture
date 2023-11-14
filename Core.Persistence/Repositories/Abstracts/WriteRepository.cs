using Core.Persistence.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities;

namespace Core.Persistence.Repositories.Abstracts
{
    public class WriteRepository<TEntity, TContext> : IWriteRepository<TEntity>

        where TEntity : BaseModel
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


        //public async Task<TEntity> AddAsync(TEntity entity)
        //{

        //    try
        //    {
        //        // Try to save changes to the database
        //        Context.Entry(entity).State = EntityState.Added;
        //        await Context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException ex)
        //    {
        //        // Get the entity that caused the concurrency exception
        //        var entry = ex.Entries.Single();
        //        // Reload the entity from the database
        //        await entry.ReloadAsync();
        //        // Apply the changes again
        //        entry.CurrentValues.SetValues(entry.OriginalValues);
        //        await Context.SaveChangesAsync();

        //    }
        //    return entity;

        //}

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            try
            {
                // Try to save changes to the database
                Context.Entry(entity).State = EntityState.Added;
                await Context.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Get the entity that caused the concurrency exception
                var entry = ex.Entries.Single();
                // Reload the entity from the database
                await entry.ReloadAsync();
                // Apply the changes again
                entry.CurrentValues.SetValues(entry.OriginalValues);
                await Context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                // Throw a new exception with the original message
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


    }
}
