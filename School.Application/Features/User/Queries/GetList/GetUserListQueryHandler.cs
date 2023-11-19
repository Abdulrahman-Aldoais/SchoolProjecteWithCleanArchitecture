using AutoMapper;
using Core.Application.Responses;
using MediatR;
using School.Application.Features.Students.Constants;
using School.Application.Features.User.Dtos.GetList;

using School.Application.Service.UserService;
using School.Persistence.Repositories.UserRepository;

namespace School.Application.Features.User.Queries.GetList
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, BaseCommandResponse<List<GetUserListOutput>>>
    {

        public readonly IUserReadRepository _userReadRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public GetUserListQueryHandler(IUserReadRepository userReadRepository, IMapper mapper, IUserService userService)
        {
            _userReadRepository = userReadRepository;
            _userService = userService;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse<List<GetUserListOutput>>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<List<GetUserListOutput>>();
            var result = await _userService.GetAllUserAsync();
            if (!result.Any())
            {
                response.Success = false;
                response.Errors = null;
                response.Message = StudentMessages.GetListNotExists;
                response.Data = new List<GetUserListOutput>();
            }
            else
            {
                var resultMapp = _mapper.Map<List<GetUserListOutput>>(result);
                response.Data = resultMapp;
                response.Success = true;
                response.Message = StudentMessages.GetListExists;
                response.Errors = null;
            }
            return response;
        }
    }
}
