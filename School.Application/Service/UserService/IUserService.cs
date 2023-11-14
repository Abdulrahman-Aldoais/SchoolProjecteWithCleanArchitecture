using School.Domain.Entities;

namespace School.Application.Service.UserService
{
    public interface IUserService
    {
        public Task<string> AddUserAsync(User user, string password);
    }
}
