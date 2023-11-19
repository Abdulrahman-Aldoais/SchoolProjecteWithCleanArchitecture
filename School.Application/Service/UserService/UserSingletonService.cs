using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using School.Application.Features.User.Dtos.GetList;
using School.Domain.Entities;
using School.Domain.Roles;
using School.Persistence.Repositories.UserRepository;

namespace School.Application.Service.UserService
{
    public class UserSingletonService : IUserService
    {

        public string UserId { get; }
        private static UserSingletonService _instance;
        private static readonly object _lock = new object();

        private readonly IUserReadRepository _userReadRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private UserSingletonService() { }
        public UserSingletonService(IUserWriteRepository userWriteRepository,
            IHttpContextAccessor httpContextAccessor,
            UserManager<ApplicationUser> userManager,
            IUserReadRepository userReadRepository)
        {
            _userManager = userManager;
            _userReadRepository = userReadRepository;
        }


        public static UserSingletonService GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new UserSingletonService();
                    }
                }
            }
            return _instance;
        }



        public async Task<string> AddUserAsync(ApplicationUser user, string password)
        {

            try
            {
                //if Email is Exist
                var existUser = await _userManager.FindByEmailAsync(user.Email);
                //email is Exist
                if (existUser != null) return "EmailIsExist";

                //if username is Exist
                var userByUserName = await _userManager.FindByNameAsync(user.UserName);
                //username is Exist
                if (userByUserName != null) return "UserNameIsExist";
                //Create
                var createUserResult = await _userManager.CreateAsync(user, password);


                if (createUserResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, UserRoles.Student);
                    return "Success";
                }
                else
                {
                    //Failed
                    return string.Join(",", createUserResult.Errors.Select(x => x.Description).ToList());
                }

            }
            catch (Exception ex)
            {
                string errorMessage = ex.InnerException?.Message ?? ex.Message;
                //return errorMessage;
                return "Failed";
            }
        }

        public async Task<List<GetUserListOutput>> GetAllUserAsync()
        {
            var query = _userReadRepository.GetAll();
            return await query.Select(x => new GetUserListOutput
            {
                Id = x.Id,
                FullName = x.FullName,
                Address = x.Address,
                Email = x.Email,
                Country = x.Country,
                Task = x.Task
            }).ToListAsync();
        }
    }
}
