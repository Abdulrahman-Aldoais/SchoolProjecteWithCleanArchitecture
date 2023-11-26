using AutoMapper;
using Core.Application.Responses;
using MediatR;
using Newtonsoft.Json;
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
        private readonly HttpClient _httpClient;
        private readonly IStudentService _studentService;

        public GetUserListQueryHandler(IStudentReadRepository studentReadRepository, HttpClient httpClient, IMapper mapper, IStudentService studentService)
        {
            _studentReadRepository = studentReadRepository;
            _studentService = studentService;
            _httpClient = httpClient;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse<List<GetStudentListOutput>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<List<GetStudentListOutput>>();

            HttpResponseMessage responseJson = await _httpClient.GetAsync("https://localhost:7014/api/Student/Api/v1/Student/List");
            if (responseJson.IsSuccessStatusCode)
            {
                string data = await responseJson.Content.ReadAsStringAsync();
                //List<GetStudentListOutput> studentInfo = JsonConvert.DeserializeObject<List<GetStudentListOutput>>(data);
                List<GetStudentListOutput> studentInfo = JsonConvert.DeserializeObject<BaseCommandResponse<List<GetStudentListOutput>>>(data).Data;

                var resultMapp = _mapper.Map<List<GetStudentListOutput>>(studentInfo);
                response.Data = resultMapp;
                response.Success = true;
                response.Message = StudentMessages.GetListExists;
                response.Errors = null;


            }
            else
            {
                response.Success = false;
                response.Errors = null;
                response.Message = StudentMessages.GetListNotExists;
                response.Data = new List<GetStudentListOutput>();
            }
            return response;
        }
    }
}
