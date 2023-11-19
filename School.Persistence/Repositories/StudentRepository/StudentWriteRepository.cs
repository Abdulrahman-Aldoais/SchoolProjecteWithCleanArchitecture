using Core.Persistence.Repositories.Abstracts;

using School.Domain.Entities;
using School.Presistence.Context;

namespace School.Persistence.Repositories.StudentRepository
{
    public class StudentWriteRepository : WriteRepository<Student, SchoolDbContext>, IStudentWriteRepository
    {
        public StudentWriteRepository(SchoolDbContext context) : base(context)
        {

        }
    }
}
