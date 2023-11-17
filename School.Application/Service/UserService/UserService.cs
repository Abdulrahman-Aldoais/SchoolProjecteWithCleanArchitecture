using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using School.Application.Repositories.UserRepository;
using School.Domain.Entities;

namespace School.Application.Service.UserService
{
    public class UserService : IUserService
    {

        public string UserId { get; }
        private readonly IUserWriteRepository _userWriteRepository;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(IUserWriteRepository userWriteRepository,
            IHttpContextAccessor httpContextAccessor,
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _userWriteRepository = userWriteRepository;
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
                var createResult = await _userManager.CreateAsync(user, password);
                //Failed
                if (!createResult.Succeeded)
                    return string.Join(",", createResult.Errors.Select(x => x.Description).ToList());

                await _userManager.AddToRoleAsync(user, "User");

                //Send Confirm Email
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var resquestAccessor = _httpContextAccessor.HttpContext.Request;
                return "Success";
            }
            catch (Exception ex)
            {
                //await trans.RollbackAsync();
                return "Failed";
            }

        }
    }
}
