using Core.Application.Responses;
using MediatR;
using School.Application.Features.Auth.Dto.GetLogin;

namespace School.Application.Features.Auth.Commands.Login
{
    public class LoginUserCommand : IRequest<BaseCommandResponse<GetLoginOutput>>
    {
        public bool RememberMe { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}