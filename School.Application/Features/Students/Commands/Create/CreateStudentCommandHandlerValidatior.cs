using FluentValidation;
using School.Application.Features.Students.Constants;
using School.Domain.Resources;
using School.Persistence.Repositories.StudentRepository;

namespace School.Application.Features.Students.Commands.Create
{
    public class CreateStudentCommandHandlerValidatior : AbstractValidator<CreateStudentCommand>
    {

        private readonly IStudentReadRepository _studentReadRepository;

        public CreateStudentCommandHandlerValidatior(IStudentReadRepository studentReadRepository)
        {
            _studentReadRepository = studentReadRepository;

            RuleFor(x => x.NameAr)
                .NotEmpty().WithMessage(SharedResourcesKeys.NotEmpty)
                .NotNull().WithMessage(SharedResourcesKeys.Required)
                .MaximumLength(100).WithMessage(SharedResourcesKeys.MaxLengthis100);

            //RuleFor(x => x.Age)
            //    .NotEmpty().WithMessage(SharedResourcesKeys.NotEmpty)
            //    .NotNull().WithMessage(SharedResourcesKeys.Required)
            //    .InclusiveBetween(18, 60).WithMessage(SharedResourcesKeys.RangAge);

            RuleFor(x => x.DID)
               .NotEmpty().WithMessage(SharedResourcesKeys.NotEmpty)
               .NotNull().WithMessage(SharedResourcesKeys.Required);



            RuleFor(x => x)
                 .MustAsync(NameCanNotBeDuplicatedWhenInserted)
                 .WithMessage(StudentMessages.NameExists);
        }
        private async Task<bool> NameCanNotBeDuplicatedWhenInserted(CreateStudentCommand e, CancellationToken token)
        {
            var result = await _studentReadRepository.GetAsync(x => x.NameAr == e.NameAr & x.StudID == e.StudID);
            return result == null;
        }
    }
}