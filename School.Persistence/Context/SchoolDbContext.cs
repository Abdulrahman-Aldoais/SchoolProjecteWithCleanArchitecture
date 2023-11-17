using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities;
using SchoolProject.Data.Entities;
using System.Reflection;

namespace School.Presistence.Context
{
    public class SchoolDbContext : IdentityDbContext<ApplicationUser>
    {


        public SchoolDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {


        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }
        public DbSet<UserRefreshToken> UserRefreshToken { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.HasDefaultSchema("notdbo");

            modelBuilder.HasDefaultSchema("Identity");

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "User");
            });
            modelBuilder.Entity<IdentityUserLogin<int>>()
           .HasKey(login => new { login.LoginProvider, login.ProviderKey });


        }



    }
}
