

using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using School.Application.Service.DepartmentService;
using School.Application.Service.StudentServices;
using School.Application.Service.UserService;
using System.Reflection;

namespace School.Application
{
    public static class ApplicationSerivceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // Services
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }

    }
}
