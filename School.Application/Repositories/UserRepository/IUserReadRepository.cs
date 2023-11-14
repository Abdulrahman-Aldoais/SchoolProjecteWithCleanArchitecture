using Core.Repositories.Interface;
using School.Domain.Entities;

namespace School.Application.Repositories.UserRepository
{
    public interface IUserReadRepository : IReadForUserRepository<ApplicationUser>
    {
    }
}
