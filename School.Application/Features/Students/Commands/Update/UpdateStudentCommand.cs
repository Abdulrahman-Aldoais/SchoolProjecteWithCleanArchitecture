using Core.Application.Responses;
using MediatR;
using School.Application.Features.Students.Dtos.Get;

namespace School.Application.Features.Students.Commands.Update
{
    public class UpdateStudentCommand : IRequest<BaseCommandResponse<GetStudentOutput>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Guid DepartmentId { get; set; }
        public string? CreatedBy { get; set; }
    }
}
