using FluentValidation;
using School.Application.Features.Students.Constants;
using School.Application.Repositories.StudentRepository;
using School.Domain.Resources;

namespace School.Application.Features.Students.Commands.Create
{
    public class CreateStudentCommandHandlerValidatior : AbstractValidator<CreateStudentCommand>
    {
        private readonly IStudentReadRepository _studentReadRepository;

        public CreateStudentCommandHandlerValidatior(IStudentReadRepository studentReadRepository)
        {
            _studentReadRepository = studentReadRepository;

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



            RuleFor(x => x)
                 .MustAsync(NameCanNotBeDuplicatedWhenInserted)
                 .WithMessage(StudentMessages.NameExists);
        }
        private async Task<bool> NameCanNotBeDuplicatedWhenInserted(CreateStudentCommand e, CancellationToken token)
        {
            var result = await _studentReadRepository.GetAsync(x => x.Name == e.Name & x.Id == e.Id);
            return result == null;
        }
    }
}