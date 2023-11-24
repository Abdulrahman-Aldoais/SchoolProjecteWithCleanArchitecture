using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using School.Domain.Entities;
using School.Persistence.Repositories.DepartmentRepository;
using School.Persistence.Repositories.StudentRepository;
using School.Persistence.Repositories.UserRepository;
using School.Presistence.Context;

namespace School.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<SchoolDbContext>(
                opt =>
                {
                    opt.UseSqlServer(ConnectionStrings.localString);
                    opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                });

            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<SchoolDbContext>()
                .AddDefaultTokenProviders();

            // Repositories
            services.AddScoped<IStudentReadRepository, StudentReadRepository>();
            services.AddScoped<IStudentWriteRepository, StudentWriteRepository>();
            services.AddScoped<IDepartmentReadRepository, DepartmentReadRepository>();
            services.AddScoped<IDepartmentWriteRepository, DepartmentWriteRepository>();
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();


            return services;
        }
    }
}
