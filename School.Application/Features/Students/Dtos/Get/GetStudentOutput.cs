using Core.Application.Responses;
using MediatR;

namespace School.Application.Features.Students.Dtos.Get
{
    public class GetStudentOutput : IRequest<BaseCommandResponse<string>>
    {
        public Guid Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public Guid StudID { get; set; }
        public int Age { get; set; }
        public Guid DID { get; set; }
        public string? CreatedBy { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string? DepartmentName { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
