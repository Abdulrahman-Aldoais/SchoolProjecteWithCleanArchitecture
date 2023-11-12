using Microsoft.AspNetCore.Mvc;
using School.Application.Features.Departments.Commands.Create;
using School.Application.Features.Departments.Queries.GetList;

namespace SchoolProjecte.Controllers
{
    public class DepartmentController : BaseController
    {
        public async Task<IActionResult> Index()
        {
            var getAllDepartment = await Mediator.Send(new GetDepartmentListQuery());

            return View(getAllDepartment.Data);
        }

        [HttpGet]
        public IActionResult AddDepartment()
        {

            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDepartment(CreateDepartmentCommand createDepartment)
        {
            var result = await Mediator.Send(createDepartment);
            if (result.Success)
            {
                NotifySuccess(result.Message);
                return RedirectToAction("Index", "Department");
            }
            else
            {
                NotifyError(result.Errors);
                return View(createDepartment);
            }

        }
    }
}
