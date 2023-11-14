using FluentValidation;
using School.Application.Repositories.UserRepository;
using School.Domain.Resources;

namespace School.Application.Features.ApplicationUser.Command.Create
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
            var existingNameUser = await _userReadRepository.GetAsync(x => x.Name == command.FullName);
            return existingNameUser == null;
        }
    }
}
