using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Entities;

namespace School.Persistence.Configurations
{
    public class DepartmentConfuguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasData(
                new Department
                {
                    Id = new Guid("75a6ff65-8b01-4981-9ca6-c550919d62b0"),
                    Name = "CS",
                    CreatedBy = "75a6ff65-8b01-4981-9ca6-c550919d62b1",
                    DateCreated = DateTime.Now,
                    Description = "Description",


                },
                 new Department
                 {
                     Id = new Guid("75a6ff65-8b01-4981-9ca6-c550919d62b2"),
                     Name = "IT",
                     CreatedBy = "75a6ff65-8b01-4981-9ca6-c550919d62b1",
                     DateCreated = DateTime.Now,
                     Description = "Description",


                 }
                 ,
                  new Department
                  {
                      Id = new Guid("75a6ff65-8b01-4981-9ca6-c550919d62b3"),
                      Name = "IS",
                      CreatedBy = "75a6ff65-8b01-4981-9ca6-c550919d62b1",
                      DateCreated = DateTime.Now,
                      Description = "Description",


                  }
                );
        }


    }
}
