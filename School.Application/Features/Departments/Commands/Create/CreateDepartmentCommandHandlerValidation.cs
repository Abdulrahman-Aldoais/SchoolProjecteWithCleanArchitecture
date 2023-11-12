using FluentValidation;
using School.Application.Repositories.DepartmentRepository;

namespace School.Application.Features.Departments.Commands.Create
{
    public class CreateDepartmentCommandHandlerValidation : AbstractValidator<CreateDepartmentCommand>
    {
        private readonly IDepartmentReadRepository _departmentReadRepository;
        public CreateDepartmentCommandHandlerValidation(IDepartmentReadRepository departmentReadRepository)
        {
            _departmentReadRepository = departmentReadRepository;

            RuleFor(x => x.Name)
                .MaximumLength(255)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x)
                 .MustAsync(NameCanNotBeDuplicatedWhenInserted)
                 .WithMessage(DepartmentMessages.NameExists);
        }
        private async Task<bool> NameCanNotBeDuplicatedWhenInserted(CreateDepartmentCommand createDepartmentCommand, CancellationToken token)
        {
            var existingDepartment = await _departmentReadRepository.GetAsync(x => x.Name == createDepartmentCommand.Name);
            return existingDepartment == null;
        }

    }
}
