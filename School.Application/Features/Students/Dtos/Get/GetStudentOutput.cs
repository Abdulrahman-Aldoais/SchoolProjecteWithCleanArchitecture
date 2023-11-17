using Core.Application.Responses;
using MediatR;
using School.Application.Features.Students.Dtos.GetList;

namespace School.Application.Features.Students.Dtos.Get
{
    public class GetStudentOutput : IRequest<BaseCommandResponse<GetStudentListOutput>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Guid DepartmentId { get; set; }
        public string? CreatedBy { get; set; }
    }
}
