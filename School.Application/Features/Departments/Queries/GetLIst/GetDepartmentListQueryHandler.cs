using AutoMapper;
using Core.Application.Responses;
using MediatR;
using School.Application.Features.Departments.Dtos.GetList;

using School.Persistence.Repositories.DepartmentRepository;

namespace School.Application.Features.Departments.Queries.GetList
{
    public class GetDepartmentQueryHandler : IRequestHandler<GetDepartmentListQuery, BaseCommandResponse<List<GetDepartmentListOutput>>>
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentReadRepository _departmentReadRepository;

        public GetDepartmentQueryHandler(IMapper mapper, IDepartmentReadRepository departmentReadRepository)
        {
            _mapper = mapper;
            _departmentReadRepository = departmentReadRepository;
        }

        public async Task<BaseCommandResponse<List<GetDepartmentListOutput>>> Handle(GetDepartmentListQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<List<GetDepartmentListOutput>>();
            var result = await _departmentReadRepository.GetListAsync();

            if (!result.Any())
            {
                response.Success = false;
                response.Message = DepartmentMessages.GetListNotExists;
                response.Errors = null;
                response.Data = new List<GetDepartmentListOutput>();
            }
            else
            {
                var resultMapp = _mapper.Map<List<GetDepartmentListOutput>>(result);
                response.Data = resultMapp;
                response.Success = true;
                response.Message = DepartmentMessages.GetListExists;
                response.Errors = null;
            }
            return response;
        }
    }
}