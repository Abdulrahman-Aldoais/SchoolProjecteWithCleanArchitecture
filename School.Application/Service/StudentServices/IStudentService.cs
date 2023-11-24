using School.Application.Features.Students.Dtos.GetList;
using School.Domain.Entities;

namespace School.Application.Service.StudentServices
{
    public interface IStudentService
    {
        public Task<List<GetStudentListOutput>> GetAllStudentAsync();
        public Task<string> UpdateStudentInfo(Student student);
        public Task<string> DeleteAsync(Student student);
        Task<Student> GetStudentByIDWithIncludeAsync(Guid id);
    }
}
