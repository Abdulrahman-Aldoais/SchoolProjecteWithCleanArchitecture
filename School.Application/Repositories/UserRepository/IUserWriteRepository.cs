using Core.Persistence.Repositories.Interface;
using School.Domain.Entities;

namespace School.Application.Repositories.UserRepository
{
    public interface IUserWriteRepository : IWriteForUserRepository<ApplicationUser>
    {

    }
}
