using School.Application.Features.User.Dtos.GetList;
using School.Domain.Entities;

namespace School.Application.Service.UserService
{
    public interface IUserService
    {
        public string UserId { get; }
        public Task<string> AddUserAsync(ApplicationUser user, string password);
        Task<List<GetUserListOutput>> GetAllUserAsync();


    }
}
