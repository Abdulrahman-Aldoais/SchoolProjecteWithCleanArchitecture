using AutoMapper;
using Core.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using School.Application.Features.Departments;
using School.Application.Features.Students.Dtos.Get;

using School.Domain.Entities;
using School.Persistence.Repositories.StudentRepository;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace School.Application.Features.Students.Commands.Create
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, BaseCommandResponse<GetStudentOutput>>
    {


        #region Filde
        private readonly IMapper _mapper;
        private readonly IStudentReadRepository _studentReadRepository;
        private readonly IStudentWriteRepository _studentWriteRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly HttpClient _httpClient;
        public string UserId { get => _contextAccessor.HttpContext?.User?.FindFirstValue("uid"); }
        #endregion

        #region Constructores
        public CreateStudentCommandHandler(

            IMapper mapper,
            IStudentReadRepository studentReadRepository,
            IStudentWriteRepository studentWriteRepository,
            IHttpContextAccessor contextAccessor,
            HttpClient httpClient

            )
        {
            _mapper = mapper;
            _studentReadRepository = studentReadRepository;
            _studentWriteRepository = studentWriteRepository;
            _contextAccessor = contextAccessor;
            _httpClient = httpClient;
        }
        #endregion

        #region Handler
        public async Task<BaseCommandResponse<GetStudentOutput>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse<GetStudentOutput>();
            var validator = new CreateStudentCommandHandlerValidatior(_studentReadRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "";
                response.Errors = validatorResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            else
            {

                var studentMapp = _mapper.Map<Student>(request);
                studentMapp.CreatedBy = UserId;
                string data = JsonSerializer.Serialize(studentMapp);

                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage responseAddStudent = await _httpClient.PostAsync("https://localhost:7014/api/Student/Api/v1/Student/Create", content);

                if (responseAddStudent.IsSuccessStatusCode)
                {
                    var responseData = await responseAddStudent.Content.ReadAsStringAsync();
                    var studentOutput = JsonSerializer.Deserialize<GetStudentOutput>(responseData);

                    response.Id = studentOutput.StudID;
                    response.Data = studentOutput;
                    response.Success = true;
                    response.Message = DepartmentMessages.CreatedSuccess;
                    response.Errors = null;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Failed to create student";
                    response.Errors = new List<string> { "Error in API call" }; // تعيين رسالة الخطأ حسب احتياجاتك
                }
            }

            return response;
        }
        #endregion
    }
}