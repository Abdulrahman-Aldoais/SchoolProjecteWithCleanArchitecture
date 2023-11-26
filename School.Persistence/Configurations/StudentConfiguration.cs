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
                   StudID = new Guid("75a6ff65-8b01-4981-9ca6-c550919d62b4"),
                   NameAr = "محمد احمد موسى",
                   NameEn = "mohamed ahmed mosa",
                   Address = "dsds",
                   DID = new Guid("75a6ff65-8b01-4981-9ca6-c550919d62b0"),
                   CreatedBy = "75a6ff65-8b01-4981-9ca6-c550919d62b1",
                   Phone = "7842345235",
                   DateCreated = DateTime.Now,
                   Age = 19,



               }

                );

        }
    }
}
