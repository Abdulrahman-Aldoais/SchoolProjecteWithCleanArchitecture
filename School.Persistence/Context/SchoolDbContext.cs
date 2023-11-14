using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using School.Domain.Entities;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Entities.Identity;
using System.Reflection;

namespace School.Presistence.Context
{
    public class SchoolDbContext : IdentityDbContext<ApplicationUser, Role, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {

        public SchoolDbContext()
        {

        }
        public SchoolDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRefreshToken> UserRefreshToken { get; set; }
        protected IConfiguration Configuration { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<IdentityUserLogin<int>>()
           .HasKey(login => new { login.LoginProvider, login.ProviderKey });


        }
    }
}
