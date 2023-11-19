using AutoMapper;
using Core.Application.Responses;
using MediatR;
using School.Application.Features.Students.Constants;
using School.Application.Features.Students.Dtos.GetList;

using School.Application.Service.StudentServices;
using School.Persistence.Repositories.StudentRepository;

namespace School.Application.Features.Students.Queries.GetList
{
    public class GetUserListQueryHandler : IRequestHandler<GetStudentListQuery, BaseCommandResponse<List<GetStudentListOutput>>>
    {

        private readonly IStudentReadRepository _studentReadRepository;
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;

        public GetUserListQueryHandler(IStudentReadRepository studentReadRepository, IMapper mapper, IStudentService studentService)
        {
            _studentReadRepository = studentReadRepository;
            _studentService = studentService;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse<List<GetStudentListOutput>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<List<GetStudentListOutput>>();
            var result = await _studentService.GetAllStudentAsync();
            if (!result.Any())
            {
                response.Success = false;
                response.Errors = null;
                response.Message = StudentMessages.GetListNotExists;
                response.Data = new List<GetStudentListOutput>();
            }
            else
            {
                var resultMapp = _mapper.Map<List<GetStudentListOutput>>(result);
                response.Data = resultMapp;
                response.Success = true;
                response.Message = StudentMessages.GetListExists;
                response.Errors = null;
            }
            return response;
        }
    }
}
