using School.Application.Features.Departments.Dtos.GetList;
using School.Application.Features.Students.Dtos.Get;

namespace SchoolProjecte.Models
{
    public class StudentCreateViewModel
    {
        public GetStudentOutput Student { get; set; }
        public List<GetDepartmentListOutput> getListDepartment { get; set; }
    }
}
