using Microsoft.AspNetCore.Mvc;
using School.Application.Features.Departments.Commands.Create;

namespace SchoolProjecte.Controllers
{
    public class DepartmentController : BaseController
    {
        public IActionResult Index()
        {
            return View();
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
                return RedirectToAction("Department", "Index");
            }
            else
            {
                NotifyError(result.Errors);
                return View(createDepartment);
            }

        }
    }
}
