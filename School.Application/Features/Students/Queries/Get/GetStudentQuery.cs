

using Core.Application.Responses;
using MediatR;
using School.Application.Features.Students.Dtos.Get;

namespace School.Application.Features.Students.Queries.Get
{
    public class GetStudentQuery : IRequest<BaseCommandResponse<GetStudentOutput>>
    {
        public Guid Id { get; set; }
    }
}