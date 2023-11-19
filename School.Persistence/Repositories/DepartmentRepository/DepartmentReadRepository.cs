
using Core.Persistence.Repositories.Abstracts;
using School.Domain.Entities;
using School.Presistence.Context;

namespace School.Persistence.Repositories.DepartmentRepository
{
    public class DepartmentReadRepository : ReadRepository<Department, SchoolDbContext>, IDepartmentReadRepository
    {
        public DepartmentReadRepository(SchoolDbContext context) : base(context)
        {

        }
    }
}
