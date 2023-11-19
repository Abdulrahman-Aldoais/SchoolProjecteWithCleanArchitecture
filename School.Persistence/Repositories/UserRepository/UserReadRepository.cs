using Core.Persistence.Repositories.Abstracts;
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
    //public class UserReadRepository : ReadForUserRepository<ApplicationUser, SchoolDbContext>, IUserReadRepository
    //{
    //    private static UserReadRepository _instance;
    //    private static SchoolDbContext context;
    //    private static readonly object _lock = new object();

    //    //public SchoolDbContext Context => _context;

    //    public UserReadRepository(SchoolDbContext context) : base(context)
    //    {
    //        //_context = context;
    //    }

    //    public static UserReadRepository Instance
    //    {
    //        get
    //        {
    //            if (_instance == null)
    //            {
    //                lock (_lock)
    //                {
    //                    if (_instance == null)
    //                    {
    //                        _instance = new UserReadRepository(context);
    //                    }
    //                }
    //            }
    //            return _instance;
    //        }
    //    }
    //}

}
