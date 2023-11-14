using Core.Persistence.Repositories.Abstracts;
using School.Application.Repositories.UserRepository;
using School.Domain.Entities;
using School.Presistence.Context;

namespace School.Persistence.Repositories.UserRepository
{

    internal class UserWriteRepository : WriteRepository<User, SchoolDbContext>, IUserWriteRepository
    {
        public UserWriteRepository(SchoolDbContext context) : base(context)
        {

        }
    }
}
