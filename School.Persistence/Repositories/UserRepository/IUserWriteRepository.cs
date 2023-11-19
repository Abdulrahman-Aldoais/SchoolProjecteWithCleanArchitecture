using Core.Persistence.Repositories.Interface;
using School.Domain.Entities;

namespace School.Persistence.Repositories.UserRepository
{
    public interface IUserWriteRepository : IWriteForUserRepository<ApplicationUser>
    {

    }
}
