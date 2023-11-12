using Core.Persistence.Repositories.Interface;
using School.Domain.Entities;

namespace School.Application.Repositories.DepartmentRepository
{
    public interface IDepartmentWriteRepository : IWriteRepository<Department>
    {
    }
}
