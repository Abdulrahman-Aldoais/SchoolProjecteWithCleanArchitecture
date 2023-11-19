using Core.Persistence.Repositories.Abstracts;
using School.Domain.Entities;
using School.Presistence.Context;

namespace School.Persistence.Repositories.StudentRepository
{
    public class StudentReadRepository : ReadRepository<Student, SchoolDbContext>, IStudentReadRepository
    {
        public StudentReadRepository(SchoolDbContext context) : base(context)
        {
        }
    }
}
