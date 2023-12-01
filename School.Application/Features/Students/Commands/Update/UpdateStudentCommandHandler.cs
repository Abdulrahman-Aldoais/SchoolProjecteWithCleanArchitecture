using AutoMapper;
using Core.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using School.Application.Features.Students.Constants;
using School.Application.Features.Students.Dtos.Get;
using School.Application.Service.StudentServices;
using School.Domain.Entities;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace School.Application.Features.Students.Commands.Update
{

    public class UpdateStudentCommandHandler : BaseCommandBaseCommandResponseHandler,
        IRequestHandler<UpdateStudentCommand, BaseCommandResponse<GetStudentOutput>>
    {

        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _contextAccessor;
        public string UserId { get => _contextAccessor.HttpContext?.User?.FindFirstValue("uid"); }
        public UpdateStudentCommandHandler(
            IMapper mapper,
            IStudentService studentService,
            HttpClient httpClient,
            IHttpContextAccessor contextAccessor)
        {

            _mapper = mapper;
            _studentService = studentService;
            _httpClient = httpClient;
            _contextAccessor = contextAccessor;
        }
        public async Task<BaseCommandResponse<GetStudentOutput>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<GetStudentOutput>();
            var validator = new UpdateStudentCommandHandlerValidation();
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
                HttpResponseMessage responseEditStudent = await _httpClient.PostAsync("https://localhost:7014/api/Student/Api/v1/Student/Create", content);

                if (responseEditStudent.IsSuccessStatusCode)
                {

                    //var dtoMapper = _mapper.Map<GetStudentOutput>(studentMapp);
                    response.Id = studentMapp.StudID;
                    response.Data = null;
                    response.Success = true;
                    response.Message = StudentMessages.UpdatedSuccess;
                    response.Errors = null;
                }
                else
                {
                    response.Success = false;
                    response.Message = "فشلت عملية تحديد بيانات الطالب";
                    response.Errors = new List<string> { "خطاء غير معروف قد يكون بسبب فشل في عملية الاتصال بالنظام الاخر " };
                }

            }
            return response;
        }
    }
}
