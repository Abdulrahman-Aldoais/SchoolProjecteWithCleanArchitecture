using Core.Application.Responses;
using MediatR;

namespace School.Application.Features.Students.Dtos.Get
{
    public class GetStudentOutput : IRequest<BaseCommandResponse<string>>
    {

        public Guid StudID { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public Guid DID { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string? DepartmentName { get; set; }

    }
}
