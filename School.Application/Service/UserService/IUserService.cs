using School.Application.Features.User.Dtos.GetList;
using School.Domain.Entities;

namespace School.Application.Service.UserService
{
    public interface IUserService
    {
        public Task<string> AddUserAsync(ApplicationUser user, string password);
        Task<List<GetUserListOutput>> GetAllUserAsync();
        public string UserId { get; }
    }
}
