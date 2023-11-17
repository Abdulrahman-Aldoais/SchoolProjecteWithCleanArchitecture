using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Entities;

namespace School.Persistence.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasData(
               new Student
               {
                   Id = new Guid("75a6ff65-8b01-4981-9ca6-c550919d62b4"),
                   Name = "محمد احمد موسى",
                   DepartmentId = new Guid("75a6ff65-8b01-4981-9ca6-c550919d62b0"),
                   CreatedBy = "75a6ff65-8b01-4981-9ca6-c550919d62b1",
                   DateCreated = DateTime.Now,
                   Age = 19,



               },
                new Student
                {
                    Id = new Guid("75a6ff65-8b01-4981-9ca6-c550919d62b5"),
                    Name = "صلاح محمود على",
                    DepartmentId = new Guid("75a6ff65-8b01-4981-9ca6-c550919d62b0"),
                    CreatedBy = "75a6ff65-8b01-4981-9ca6-c550919d62b1",
                    DateCreated = DateTime.Now,



                }

                );

        }
    }
}
