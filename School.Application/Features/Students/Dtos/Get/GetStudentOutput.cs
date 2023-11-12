using Core.Application.Responses;
using MediatR;
using School.Application.Features.Students.Dtos.GetList;
using School.Domain.Entities;

namespace School.Application.Features.Students.Dtos.Get
{
    public class GetStudentOutput : IRequest<BaseCommandResponse<GetStudentListOutput>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int DepartmentId { get; set; }
        public Department Departments { get; set; }
    }
}
