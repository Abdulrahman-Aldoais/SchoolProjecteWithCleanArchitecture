
using AutoMapper;
using Core.Application.Responses;
using MediatR;
using School.Application.Features.Students.Constants;
using School.Application.Features.Students.Dtos.Get;
using School.Application.Service.StudentServices;
using School.Persistence.Repositories.StudentRepository;

namespace School.Application.Features.Students.Queries.Get
{
    public class GetStudentQueryHandler : IRequestHandler<GetStudentQuery, BaseCommandResponse<GetStudentOutput>>
    {
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;
        private readonly IStudentReadRepository _studentReadRepository;
        private readonly HttpClient _httpClient;

        public GetStudentQueryHandler(IMapper mapper, IStudentService studentService, IStudentReadRepository studentReadRepository, HttpClient httpClient)
        {
            _mapper = mapper;
            _studentService = studentService;
            _studentReadRepository = studentReadRepository;
            _httpClient = httpClient;
        }

        //public async Task<BaseCommandResponse<GetStudentOutput>> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        //{
        //    var response = new BaseCommandResponse<GetStudentOutput>();
        //    var validator = new GetStudentQueryHandlerValidatior(_studentReadRepository, _httpClient);
        //    var validatorResult = await validator.ValidateAsync(request, cancellationToken);

        //    if (!validatorResult.IsValid)
        //    {
        //        response.Data = null;
        //        response.Success = false;
        //        response.Message = null;
        //        response.Errors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList();
        //    }
        //    else
        //    {

        //        HttpResponseMessage responseHttp = await _httpClient.GetAsync("https://localhost:7014/api/Student/Api/v1/Student/" + request.Id);

        //        if (responseHttp.IsSuccessStatusCode)
        //        {

        //            string data = await responseHttp.Content.ReadAsStringAsync();
        //            GetStudentOutput studentInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<GetStudentOutput>(data);

        //            response.Id = studentInfo.StudID;
        //            response.Data = studentInfo;
        //            response.Success = true;
        //            response.Message = StudentMessages.UpdatedSuccess;
        //            response.Errors = null;
        //        }
        //        else
        //        {
        //            response.Success = false;
        //            response.Message = "فشلت عملية جلب بيانات الطالب";
        //            response.Errors = new List<string> { "خطاء غير معروف قد يكون بسبب فشل في عملية الاتصال بالنظام الاخر " };
        //        }

        //    }
        //    return response;
        //}

        public async Task<BaseCommandResponse<GetStudentOutput>> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<GetStudentOutput>();
            var validator = new GetStudentQueryHandlerValidatior(_studentReadRepository, _httpClient);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                response.Success = false;
                response.Errors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            HttpResponseMessage responseHttp = await _httpClient.GetAsync("https://localhost:7014/api/Student/Api/v1/Student/" + request.Id);

            if (responseHttp.IsSuccessStatusCode)
            {
                string data = await responseHttp.Content.ReadAsStringAsync();

                // Deserialize the JSON into a temporary object to maintain API's property order
                GetStudentOutput studentInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<BaseCommandResponse<GetStudentOutput>>(data).Data;

                var resultMapp = _mapper.Map<GetStudentOutput>(studentInfo);

                response.Id = resultMapp.StudID;
                response.Data = resultMapp;
                response.Success = true;
                response.Message = StudentMessages.UpdatedSuccess;
            }
            else
            {
                response.Success = false;
                response.Message = "فشلت عملية جلب بيانات الطالب";
                response.Errors = new List<string> { "خطاء غير معروف قد يكون بسبب فشل في عملية الاتصال بالنظام الاخر " };
            }

            return response;
        }



    }
}