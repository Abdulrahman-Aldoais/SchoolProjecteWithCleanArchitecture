using FluentValidation;
using School.Application.Features.Students.Constants;
using School.Application.Features.Students.Dtos.Get;
using School.Persistence.Repositories.StudentRepository;

namespace School.Application.Features.Students.Queries.Get
{
    public class GetStudentQueryHandlerValidatior : AbstractValidator<GetStudentQuery>
    {
        private readonly IStudentReadRepository _studentReadRepository;
        private readonly HttpClient _httpClient;
        public GetStudentQueryHandlerValidatior(IStudentReadRepository studentReadRepository, HttpClient httpClient)
        {
            _studentReadRepository = studentReadRepository;

            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x)
               .MustAsync(IdIsNotExists)
               .WithMessage(StudentMessages.GetByIdNotExists);
            _httpClient = httpClient;
        }

        //private async Task<bool> IdIsNotExists(GetStudentQuery e, CancellationToken token)
        //{
        //    var result = await _studentReadRepository.GetAsync(x => x.Id == e.Id);
        //    return result != null;
        //}

        private async Task<bool> IdIsNotExists(GetStudentQuery e, CancellationToken token)
        {
            HttpResponseMessage responseHttp = await _httpClient.GetAsync("https://localhost:7014/api/Student/Api/v1/Student/" + e.Id);

            if (responseHttp.IsSuccessStatusCode)
            {
                //GetStudentOutput student = await responseHttp.Content.ReadAsAsync<GetStudentOutput>();
                string data = await responseHttp.Content.ReadAsStringAsync();
                GetStudentOutput studentInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<GetStudentOutput>(data);
                if (studentInfo != null)
                {
                    return true;
                }

            }
            return false;
        }
    }
}