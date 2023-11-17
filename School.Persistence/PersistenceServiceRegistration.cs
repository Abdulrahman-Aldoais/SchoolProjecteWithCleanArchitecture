using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using School.Application.Repositories.DepartmentRepository;
using School.Application.Repositories.StudentRepository;
using School.Application.Repositories.UserRepository;
using School.Domain.Entities;
using School.Persistence.Repositories.DepartmentRepository;
using School.Persistence.Repositories.UserRepository;
using School.Presistence.Context;
using School.Presistence.Repositories.StudentRepository;

namespace School.Presistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
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
            //services.Configure<Potions>(Configuration)
            services.AddScoped<IStudentReadRepository, StudentReadRepository>();
            services.AddScoped<IStudentWriteRepository, StudentWriteRepository>();
            services.AddScoped<IDepartmentReadRepository, DepartmentReadRepository>();
            services.AddScoped<IDepartmentWriteRepository, DepartmentWriteRepository>();
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();




            return services;
        }
    }
}
