using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Roles;

namespace School.Persistence.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {

            builder.HasData(
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = UserRoles.Admin,
                    NormalizedName = UserRoles.Admin.ToLower(),
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = UserRoles.Student,
                    NormalizedName = UserRoles.Student.ToLower(),
                }
            );
        }
    }
}
