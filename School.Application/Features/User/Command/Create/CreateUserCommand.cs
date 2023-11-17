using Core.Application.Responses;
using MediatR;

namespace School.Application.Features.User.Command.Create
{
    public class CreateUserCommand : IRequest<BaseCommandResponse<string>>
    {
        //public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Task { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
    }
}
