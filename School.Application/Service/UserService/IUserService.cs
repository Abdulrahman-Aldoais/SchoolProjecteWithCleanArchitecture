using School.Domain.Entities;

namespace School.Application.Service.UserService
{
    public interface IUserService
    {
        public Task<string> AddUserAsync(ApplicationUser user, string password);
        public string UserId { get; }
    }
}
