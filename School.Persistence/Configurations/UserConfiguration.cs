using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using School.Domain.Entities;
using School.Domain.Roles;

namespace School.Persistence.Configurations
{
    public class UsersConfiguration
    {


        public static async Task SeedUsersAndRolesAsync(IServiceProvider serviceProvider)
        {
            // Roles
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var rolesToCreate = new List<(string RoleName, string RoleDisplayName)>
    {
        (UserRoles.Admin, "Admin"),
        (UserRoles.Student, "Student")
    };

            foreach (var roleData in rolesToCreate)
            {
                var (roleName, roleDisplayName) = roleData;

                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName) { Name = roleDisplayName });
                }
            }

            // Users
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var usersToCreate = new List<(ApplicationUser User, string RoleName)>
    {
        (new ApplicationUser
        {
            Id="75a6ff65-8b01-4981-9ca6-c550919d62b1",
            FullName = "عبدالرحمن علي سرحان الدعيس",
            Email = "admin@example.com",
            EmailConfirmed = true,
            Address = "اليمن",
            Task = "",
            UserName = "admin@example.com"
        }, UserRoles.Admin),
        (new ApplicationUser
        {
            FullName = "صلاح سعيد على احمد",
            Email = "student@example.com",
            EmailConfirmed = true,
            Address = "اليمن",
            Task = "",
            UserName = "student@example.com"
        }, UserRoles.Student)
    };

            foreach (var userData in usersToCreate)
            {
                var (user, roleName) = userData;

                var existingUser = await userManager.FindByEmailAsync(user.Email);
                if (existingUser == null)
                {
                    var result = await userManager.CreateAsync(user, "Coding@2023");
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, roleName);
                    }
                }
            }
        }
    }
}
