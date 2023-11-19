using FluentValidation;
using School.Domain.Resources;

namespace School.Application.Features.User.Command.Create
{
    public class CreateUserCommandHandlerValidation : AbstractValidator<CreateUserCommand>
    {

        public CreateUserCommandHandlerValidation()
        {

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
    }
}
