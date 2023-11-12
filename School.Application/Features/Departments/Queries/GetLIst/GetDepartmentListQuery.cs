using Core.Application.Responses;
using MediatR;
using School.Application.Features.Departments.Dtos.GetList;

namespace School.Application.Features.Departments.Queries.GetList
{
    public class GetDepartmentListQuery : IRequest<BaseCommandResponse<List<GetDepartmentListOutput>>>
    {

    }
}
