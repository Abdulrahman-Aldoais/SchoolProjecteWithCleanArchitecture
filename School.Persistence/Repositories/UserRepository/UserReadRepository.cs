using Core.Persistence.Repositories.Abstracts;
using School.Application.Repositories.UserRepository;
using School.Domain.Entities;
using School.Presistence.Context;

namespace School.Persistence.Repositories.UserRepository
{

    public class UserReadRepository : ReadForUserRepository<ApplicationUser, SchoolDbContext>, IUserReadRepository
    {
        public UserReadRepository(SchoolDbContext context) : base(context)
        {

        }
    }
}
