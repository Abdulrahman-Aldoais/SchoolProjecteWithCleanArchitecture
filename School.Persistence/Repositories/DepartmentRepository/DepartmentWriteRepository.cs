using Core.Persistence.Repositories.Abstracts;
using School.Application.Repositories.DepartmentRepository;
using School.Domain.Entities;
using School.Presistence.Context;

namespace School.Persistence.Repositories.DepartmentRepository
{
    public class DepartmentWriteRepository : WriteRepository<Department, SchoolDbContext>, IDepartmentWriteRepository
    {
        public DepartmentWriteRepository(SchoolDbContext context) : base(context)
        {

        }
    }
}
