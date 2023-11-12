using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using School.Application.Repositories.DepartmentRepository;
using School.Application.Repositories.StudentRepository;
using School.Persistence.Repositories.DepartmentRepository;
using School.Presistence.Context;
using School.Presistence.Repositories.StudentRepository;

namespace School.Presistence
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

            // Repositories
            //services.Configure<Potions>(Configuration)
            services.AddScoped<IStudentReadRepository, StudentReadRepository>();
            services.AddScoped<IStudentWriteRepository, StudentWriteRepository>();
            services.AddScoped<IDepartmentReadRepository, DepartmentReadRepository>();
            services.AddScoped<IDepartmentWriteRepository, DepartmentWriteRepository>();
            //services.AddScoped<IUserReadRepository, UserReadRepository>();

            return services;
        }
    }
}
