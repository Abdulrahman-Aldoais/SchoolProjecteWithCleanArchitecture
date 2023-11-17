using Core.Persistence.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities;
using System.Security.Claims;

namespace Core.Persistence.Repositories.Abstracts
{
    public class WriteForUserRepository<TEntity, TContext> : IWriteForUserRepository<TEntity>

        where TEntity : BaseModel

        where TContext : DbContext
    {
        protected TContext Context;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public string UserId { get => _contextAccessor.HttpContext?.User?.FindFirstValue("uid"); }

        public WriteForUserRepository(TContext context, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
        {
            _contextAccessor = httpContextAccessor;
            _userManager = userManager;
            Context = context;
        }

        public TEntity Add(TEntity entity)
        {
            var entry = Context.Entry(entity);
            Context.Set<TEntity>().Add(entity);
            entry.Property(e => e.CreatedBy).CurrentValue = UserId;
            if (entry.State == EntityState.Added)
            {
                entry.Entity.DateCreated = DateTime.Now;
                entry.Entity.CreatedBy = UserId;
            }
            Context.SaveChanges();
            return entity;
        }
        //public TEntity Add(TEntity entity)
        //{
        //    Context.Entry(entity).State = EntityState.Added;
        //    Context.SaveChanges();
        //    return entity;
        //}


        public async Task<TEntity> AddAsync(TEntity entity)
        {
            try
            {
                //Context.Entry(entity).State = EntityState.Added;
                //await Context.SaveChangesAsync();
                //return entity;

                var entry = Context.Entry(entity);
                await Context.Set<TEntity>().AddAsync(entity);
                entry.Property(e => e.CreatedBy).CurrentValue = UserId;
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                    entry.Entity.CreatedBy = UserId;
                }
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


    }
}
