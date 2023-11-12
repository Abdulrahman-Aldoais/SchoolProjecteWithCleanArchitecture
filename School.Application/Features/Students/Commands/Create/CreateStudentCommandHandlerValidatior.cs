using FluentValidation;
using School.Application.Features.Students.Constants;
using School.Application.Repositories.StudentRepository;

namespace School.Application.Features.Students.Commands.Create
{
    public class CreateStudentCommandHandlerValidatior : AbstractValidator<CreateStudentCommand>
    {
        private readonly IStudentReadRepository _studentReadRepository;

        public CreateStudentCommandHandlerValidatior(IStudentReadRepository studentReadRepository)
        {
            _studentReadRepository = studentReadRepository;

            RuleFor(x => x.DepartmentId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Name)
                .MaximumLength(255)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x)
                 .MustAsync(NameCanNotBeDuplicatedWhenInserted)
                 .WithMessage(DepartmentMessages.NameExists);
        }
        private async Task<bool> NameCanNotBeDuplicatedWhenInserted(CreateStudentCommand e, CancellationToken token)
        {
            var result = await _studentReadRepository.GetAsync(x => x.Name == e.Name & x.Id == e.Id);
            return result == null;
        }
    }
}