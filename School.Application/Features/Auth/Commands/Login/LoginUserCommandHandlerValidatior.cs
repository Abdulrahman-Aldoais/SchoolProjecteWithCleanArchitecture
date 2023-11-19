using FluentValidation;
using School.Persistence.Repositories.UserRepository;

namespace School.Application.Features.Auth.Commands.Login
{
    public class LoginUserCommandHandlerValidatior : AbstractValidator<LoginUserCommand>
    {
        private readonly IUserReadRepository _userReadRepository;

        public LoginUserCommandHandlerValidatior(IUserReadRepository userReadRepository)
        {
            _userReadRepository = userReadRepository;

            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull();

        }


    }
}