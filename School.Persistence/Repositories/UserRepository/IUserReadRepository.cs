
using Core.Repositories.Interface;
using School.Domain.Entities;

namespace School.Persistence.Repositories.UserRepository
{
    public interface IUserReadRepository : IReadForUserRepository<ApplicationUser>
    {

    }
}
