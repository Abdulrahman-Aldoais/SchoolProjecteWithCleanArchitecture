using Microsoft.AspNetCore.Mvc;
using School.Application.Features.Departments.Queries.GetList;
using School.Application.Features.Students.Commands.Create;
using School.Application.Features.Students.Dtos.Get;
using SchoolProjecte.Models;

namespace SchoolProjecte.Controllers
{
    public class StudentController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AddStudent()
        {
            var getListDepartment = await Mediator.Send(new GetDepartmentListQuery());

           
            var model = new StudentCreateViewModel
            {
                Student = new GetStudentOutput(), 
                getListDepartment = getListDepartment.Data.ToList()
            };

            return View(model);
        }
      
        [HttpPost, ValidateAntiForgeryToken]
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
                return RedirectToAction("AddStudent", "Student");
            }
            else
            {
                NotifyError(result.Errors);
                return View(model);
            }
        }

    }
}
