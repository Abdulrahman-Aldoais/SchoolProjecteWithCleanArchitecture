using School.Application.Features.Students.Dtos.GetList;

namespace School.Application.Service.StudentServices
{
    public interface IStudentService
    {
        public Task<List<GetStudentListOutput>> GetAllStudentAsync();
    }
}
