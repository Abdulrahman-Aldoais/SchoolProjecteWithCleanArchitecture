using School.Application.Features.Departments.Dtos.Get;
using School.Application.Features.Students.Dtos.Get;

namespace SchoolProjecte.Models
{
    public class StudentCreateViewModel
    {
        public GetStudentOutput Student { get; set; }
        public List<GetDepartmentOutput> getListDepartment { get; set; }
    }
}
