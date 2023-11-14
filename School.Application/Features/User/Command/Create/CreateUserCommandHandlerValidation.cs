using FluentValidation;
using School.Application.Repositories.UserRepository;
using School.Domain.Resources;

namespace School.Application.Features.User.Command.Create
{
    public class CreateUserCommandHandlerValidation : AbstractValidator<CreateUserCommand>
    {
        private readonly IUserReadRepository _userReadRepository;
        public CreateUserCommandHandlerValidation(IUserReadRepository userReadRepository)
        {
            _userReadRepository = userReadRepository;


            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage(SharedResourcesKeys.NotEmpty)
                .NotNull().WithMessage(SharedResourcesKeys.Required);


            RuleFor(x => x.Address)
            .NotEmpty().WithMessage(SharedResourcesKeys.NotEmpty)
            .NotNull().WithMessage(SharedResourcesKeys.Required);

            RuleFor(x => x.Country)
            .NotEmpty().WithMessage(SharedResourcesKeys.NotEmpty)
            .NotNull().WithMessage(SharedResourcesKeys.Required);
        }
        private async Task<bool> NameCanNotBeDuplicatedWhenInserted(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var existingNameUser = await _userReadRepository.GetAsync(x => x.FullName == command.FullName);
            return existingNameUser == null;
        }
    }
}
