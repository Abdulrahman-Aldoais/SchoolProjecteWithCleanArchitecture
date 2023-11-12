using Core.Application.Responses;
using MediatR;

namespace School.Application.Features.Students.Dtos.Get
{
    public class GetStudentOutput : IRequest<BaseCommandResponse<GetStudentOutput>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int DepartmentId { get; set; }
    }
}
