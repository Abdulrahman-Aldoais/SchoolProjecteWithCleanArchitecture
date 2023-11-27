using AutoMapper;
using Core.Application.Responses;
using MediatR;
using Newtonsoft.Json;
using School.Application.Features.Departments.Dtos.GetList;

using School.Persistence.Repositories.DepartmentRepository;

namespace School.Application.Features.Departments.Queries.GetList
{
    public class GetDepartmentQueryHandler : IRequestHandler<GetDepartmentListQuery, BaseCommandResponse<List<GetDepartmentListOutput>>>
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentReadRepository _departmentReadRepository;
        private readonly HttpClient _httpClient;
        public GetDepartmentQueryHandler(IMapper mapper, IDepartmentReadRepository departmentReadRepository, HttpClient httpClient)
        {
            _mapper = mapper;
            _departmentReadRepository = departmentReadRepository;
            _httpClient = httpClient;
        }

        public async Task<BaseCommandResponse<List<GetDepartmentListOutput>>> Handle(GetDepartmentListQuery request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse<List<GetDepartmentListOutput>>();

            HttpResponseMessage responseJson = await _httpClient.GetAsync("https://localhost:7014/api/Department/GetDepartmentList");
            if (responseJson.IsSuccessStatusCode)
            {
                string data = await responseJson.Content.ReadAsStringAsync();
                List<GetDepartmentListOutput> studentInfo = JsonConvert.DeserializeObject<BaseCommandResponse<List<GetDepartmentListOutput>>>(data).Data;

                var resultMapp = _mapper.Map<List<GetDepartmentListOutput>>(studentInfo);
                response.Data = resultMapp;
                response.Success = true;
                response.Message = DepartmentMessages.GetListExists;
                response.Errors = null;


            }
            else
            {
                response.Success = false;
                response.Errors = null;
                response.Message = DepartmentMessages.GetListNotExists;
                response.Data = new List<GetDepartmentListOutput>();
            }
            return response;

            //var response = new BaseCommandResponse<List<GetDepartmentListOutput>>();
            //var result = await _departmentReadRepository.GetListAsync();

            //if (!result.Any())
            //{
            //    response.Success = false;
            //    response.Message = DepartmentMessages.GetListNotExists;
            //    response.Errors = null;
            //    response.Data = new List<GetDepartmentListOutput>();
            //}
            //else
            //{
            //    var resultMapp = _mapper.Map<List<GetDepartmentListOutput>>(result);
            //    response.Data = resultMapp;
            //    response.Success = true;
            //    response.Message = DepartmentMessages.GetListExists;
            //    response.Errors = null;
            //}
            //return response;
        }
    }
}