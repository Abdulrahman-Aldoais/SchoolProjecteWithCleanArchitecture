using Core.Application.Responses;
using MediatR;
using School.Application.Features.Students.Dtos.GetList;

namespace School.Application.Features.Students.Queries.GetList
{
    public class GetStudentListQuery : IRequest<BaseCommandResponse<List<GetStudentListOutput>>>
    {

    }
}
