using FluentValidation;
using School.Domain.Resources;

namespace School.Application.Features.Students.Commands.Update
{
    public class UpdateStudentCommandHandlerValidation : AbstractValidator<UpdateStudentCommand>
    {


        public UpdateStudentCommandHandlerValidation()
        {


            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(SharedResourcesKeys.NotEmpty)
                .NotNull().WithMessage(SharedResourcesKeys.Required)
                .MaximumLength(100).WithMessage(SharedResourcesKeys.MaxLengthis100);

            RuleFor(x => x.Age)
                .NotEmpty().WithMessage(SharedResourcesKeys.NotEmpty)
                .NotNull().WithMessage(SharedResourcesKeys.Required)
                .InclusiveBetween(18, 60).WithMessage(SharedResourcesKeys.RangAge);

            RuleFor(x => x.DepartmentId)
               .NotEmpty().WithMessage(SharedResourcesKeys.NotEmpty)
               .NotNull().WithMessage(SharedResourcesKeys.Required);

        }

    }
}