using Core.Application.Responses;
using MediatR;

namespace School.Application.Features.Students.Dtos.Get
{
    public class GetStudentOutput : IRequest<BaseCommandResponse<string>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public DateTime DateCreated { get; set; }
        public string? CreatedBy { get; set; }
    }
}
