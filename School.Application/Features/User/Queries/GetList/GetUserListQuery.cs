using Core.Application.Responses;
using MediatR;
using School.Application.Features.User.Dtos.GetList;

namespace School.Application.Features.User.Queries.GetList
{
    public class GetUserListQuery : IRequest<BaseCommandResponse<List<GetUserListOutput>>>
    {

    }
}
