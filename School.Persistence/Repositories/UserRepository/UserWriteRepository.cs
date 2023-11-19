using Core.Persistence.Repositories.Abstracts;
using School.Domain.Entities;
using School.Presistence.Context;

namespace School.Persistence.Repositories.UserRepository
{

    public class UserWriteRepository : WriteRepository<ApplicationUser, SchoolDbContext>, IUserWriteRepository
    {
        public UserWriteRepository(SchoolDbContext context) : base(context)
        {

        }
    }

    //    public class UserWriteSingletonRepository : WriteRepository<ApplicationUser, SchoolDbContext>, IUserWriteRepository
    //    {
    //        private static UserWriteSingletonRepository _instance;
    //        private static readonly object _lock = new object();

    //        private UserWriteSingletonRepository(SchoolDbContext context) : base(context)
    //        {

    //        }

    //        public static UserWriteSingletonRepository GetInstance(SchoolDbContext context)
    //        {
    //            if (_instance == null)
    //            {
    //                lock (_lock)
    //                {
    //                    if (_instance == null)
    //                    {
    //                        _instance = new UserWriteSingletonRepository(context);
    //                    }
    //                }
    //            }
    //            return _instance;
    //        }
    //    }
}
