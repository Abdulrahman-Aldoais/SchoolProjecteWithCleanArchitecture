using Core.Application.Responses;
using MediatR;
using School.Application.Features.ApplicationUser.Dtos.Get;

namespace School.Application.Features.ApplicationUser.Command.Create
{
    public class CreateUserCommand : IRequest<BaseCommandResponse<GetUserOutput>>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string Password { get; set; }
    }
}
