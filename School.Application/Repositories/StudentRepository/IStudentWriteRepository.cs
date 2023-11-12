using Core.Persistence.Repositories.Interface;
using School.Domain.Entities;

namespace School.Application.Repositories.StudentRepository
{
    public interface IStudentWriteRepository : IWriteRepository<Student>
    {

    }
}
