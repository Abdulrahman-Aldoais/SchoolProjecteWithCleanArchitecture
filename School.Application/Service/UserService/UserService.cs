using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using School.Application.Features.User.Dtos.GetList;
using School.Application.Repositories.UserRepository;
using School.Domain.Entities;
using School.Domain.Roles;

namespace School.Application.Service.UserService
{
    public class UserService : IUserService
    {

        public string UserId { get; }
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly IUserReadRepository _userReadRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(IUserWriteRepository userWriteRepository,
            IHttpContextAccessor httpContextAccessor,
            UserManager<ApplicationUser> userManager,
            IUserReadRepository userReadRepository)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _userWriteRepository = userWriteRepository;
            _userReadRepository = userReadRepository;
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

                //var resquestAccessor = _httpContextAccessor.HttpContext.Request;
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
