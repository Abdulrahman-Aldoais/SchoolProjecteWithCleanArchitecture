using FluentValidation;
using School.Application.Features.Students.Constants;
using School.Persistence.Repositories.StudentRepository;

namespace School.Application.Features.Students.Commands.Delete
{
    public class CreateStudentCommandHandlerValidation : AbstractValidator<DeleteStudentCommand>
    {
        private readonly IStudentReadRepository _studentReadRepository;

        public CreateStudentCommandHandlerValidation(IStudentReadRepository studentReadRepository)
        {
            _studentReadRepository = studentReadRepository;

            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x)
               .MustAsync(IdIsNotExists)
               .WithMessage(StudentMessages.GetByIdNotExists);

        }

        private async Task<bool> IdIsNotExists(DeleteStudentCommand e, CancellationToken token)
        {
            var result = await _studentReadRepository.GetAsync(x => x.Id == e.Id);
            return result != null;
        }
    }
}