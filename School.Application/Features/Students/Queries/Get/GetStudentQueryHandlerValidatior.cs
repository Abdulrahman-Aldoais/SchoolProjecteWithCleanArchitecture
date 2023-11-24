

using FluentValidation;
using School.Application.Features.Students.Constants;
using School.Persistence.Repositories.StudentRepository;

namespace School.Application.Features.Students.Queries.Get
{
    public class GetStudentQueryHandlerValidatior : AbstractValidator<GetStudentQuery>
    {
        private readonly IStudentReadRepository _studentReadRepository;
        public GetStudentQueryHandlerValidatior(IStudentReadRepository studentReadRepository)
        {
            _studentReadRepository = studentReadRepository;

            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x)
               .MustAsync(IdIsNotExists)
               .WithMessage(StudentMessages.GetByIdNotExists);
        }
        private async Task<bool> IdIsNotExists(GetStudentQuery e, CancellationToken token)
        {
            var result = await _studentReadRepository.GetAsync(x => x.Id == e.Id);
            return result != null;
        }
    }
}