using Microsoft.AspNetCore.Mvc;
using School.Application.Features.Departments.Queries.GetList;
using School.Application.Features.Students.Commands.Create;
using School.Application.Features.Students.Dtos.Get;
using School.Application.Features.Students.Queries.GetList;
using SchoolProjecte.Models;

namespace SchoolProjecte.Controllers
{
    public class StudentController : BaseController
    {
        public async Task<IActionResult> Index()
        {
            var getAllStudent = await Mediator.Send(new GetStudentListQuery());

            return View(getAllStudent.Data);
        }
        [HttpGet]

        public async Task<IActionResult> AddStudent()
        {
            var getListDepartment = await Mediator.Send(new GetDepartmentListQuery());


            var model = new StudentCreateViewModel
            {
                Student = new GetStudentOutput(),
                getListDepartment = getListDepartment.Data
            };

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        [Route("student/addStudent/")]
        public async Task<IActionResult> AddStudent(StudentCreateViewModel model)
        {
            var createStudentCommand = new CreateStudentCommand()
            {
                Age = model.Student.Age,
                Name = model.Student.Name,
                DepartmentId = model.Student.DepartmentId,
            };

            var result = await Mediator.Send(createStudentCommand);

            if (result.Success)
            {
                NotifySuccess(result.Message);
                return RedirectToAction("Index", "Student");
            }
            else
            {
                NotifyError(result.Errors);
                return View(model);
            }
        }

    }
}
