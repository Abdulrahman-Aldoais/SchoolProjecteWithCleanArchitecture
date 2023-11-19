

using Core.Application.FormAuth.ClaimServices;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
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
            services.AddScoped<IUserService, UserSingletonService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IClaimCoreService, ClaimCoreService>();
            services.AddScoped<IUserService, UserSingletonService>(
            provider => provider.GetRequiredService<UserSingletonService>()
                         );




            return services;
        }

    }
}
