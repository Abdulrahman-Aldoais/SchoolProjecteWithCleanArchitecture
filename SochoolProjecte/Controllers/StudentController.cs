using Microsoft.AspNetCore.Mvc;
using School.Application.Features.Departments.Queries.GetList;
using School.Application.Features.Students.Commands.Create;
using School.Application.Features.Students.Commands.Delete;
using School.Application.Features.Students.Commands.Update;
using School.Application.Features.Students.Dtos.Get;
using School.Application.Features.Students.Queries.Get;
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
        [Route("student/addStudent")]
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
                var getListDepartment = await Mediator.Send(new GetDepartmentListQuery());


                var modell = new StudentCreateViewModel
                {
                    Student = new GetStudentOutput(),
                    getListDepartment = getListDepartment.Data
                };

                return View(modell);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(GetStudentQuery getStudent)
        {
            if (getStudent.Id == Guid.Empty) return RedirectToAction("Index", "Student");
            var getListDepartment = await Mediator.Send(new GetDepartmentListQuery());

            var getStudentInformation = await Mediator.Send(getStudent);
            var model = new StudentCreateViewModel
            {
                Student = getStudentInformation.Data,
                getListDepartment = getListDepartment.Data
            };

            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(StudentCreateViewModel model)
        {
            var createStudentCommand = new UpdateStudentCommand()
            {
                Id = model.Student.Id,
                Age = model.Student.Age,
                Name = model.Student.Name,
                DepartmentId = model.Student.DepartmentId,
            };
            var response = await Mediator.Send(createStudentCommand);
            if (response.Success)
            {
                NotifySuccess(response.Message);
                return RedirectToAction("Index", "Student");
            }
            else
            {

                NotifyError(response.Errors);
                var getListDepartment = await Mediator.Send(new GetDepartmentListQuery());


                var modell = new StudentCreateViewModel
                {
                    Student = new GetStudentOutput(),
                    getListDepartment = getListDepartment.Data
                };

                return View(modell);
            }
        }



        public async Task<IActionResult> Delete(DeleteStudentCommand input)
        {
            var result = await Mediator.Send(input);
            return await NewResult(result, () =>
            {
                if (result.Success)
                {
                    //TempData["success"] = result.Message;
                    NotifySuccess(result.Message);
                    return RedirectToAction("Index", "Student");
                }
                else
                {
                    //TempData["error"] = result.Message;
                    NotifyError(result.Errors);
                    return View();
                }
            });
        }

    }
}
