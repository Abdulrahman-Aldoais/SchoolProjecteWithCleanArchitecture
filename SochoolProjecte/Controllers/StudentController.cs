using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using School.Application.Features.Departments.Dtos.GetList;
using School.Application.Features.Departments.Queries.GetList;
using School.Application.Features.Students.Commands.Create;
using School.Application.Features.Students.Commands.Delete;
using School.Application.Features.Students.Commands.Update;
using School.Application.Features.Students.Dtos.Get;
using School.Application.Features.Students.Dtos.GetList;
using School.Application.Features.Students.Queries.Get;
using School.Application.Features.Students.Queries.GetList;
using School.Domain.Entities;
using SchoolProjecte.Models;

namespace SchoolProjecte.Controllers
{
    public class StudentController : BaseController
    {
        #region Filed
        private static List<GetDepartmentListOutput> _cachedDepartments;
        private static DateTime _cacheExpirationTime = DateTime.MinValue;
        private static readonly TimeSpan CacheDuration = TimeSpan.FromMinutes(30);
        private readonly ILogger<StudentController> _logger;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor httpContextAccessor;
        #endregion

        public StudentController(
            ILogger<StudentController> logger,
            UserManager<ApplicationUser> userManager,
             HttpClient httpClient,
             IHttpContextAccessor httpContextAccessor
             )
        {
            _logger = logger;
            this.userManager = userManager;
            //_httpClient = new HttpClient();
            _httpClient = httpClient;
            this.httpContextAccessor = httpContextAccessor;
            _httpClient.BaseAddress = new Uri("https://localhost:7014/api/");
        }

        #region Action
        public async Task<ActionResult<List<GetStudentListOutput>>> Index()
        {

            var getAllStudent = await Mediator.Send(new GetStudentListQuery());

            return View(getAllStudent.Data);

        }


        [HttpGet]

        public async Task<IActionResult> AddStudent()
        {
            if (_cachedDepartments == null || DateTime.UtcNow > _cacheExpirationTime)
            {
                var getListDepartment = await Mediator.Send(new GetDepartmentListQuery());
                _cachedDepartments = getListDepartment.Data;
                List<GetDepartmentListOutput> convertedDepartments = _cachedDepartments
                    .Select(department => new GetDepartmentListOutput
                    {

                        Id = department.Id,
                        Name = department.Name,
                    })
                    .ToList();

                _cacheExpirationTime = DateTime.UtcNow + CacheDuration;

                var model = new StudentCreateViewModel
                {
                    Student = new GetStudentOutput(),
                    getListDepartment = convertedDepartments
                };

                return View(model);
            }


            var cachedModel = new StudentCreateViewModel
            {
                Student = new GetStudentOutput(),
                getListDepartment = _cachedDepartments
            };

            return View(cachedModel);
        }


        [HttpPost, ValidateAntiForgeryToken]
        [Route("student/addStudent")]
        public async Task<IActionResult> AddStudent(StudentCreateViewModel model)
        {
            var createStudentCommand = new CreateStudentCommand()
            {
                Address = model.Student.Address,
                DepartmentName = model.Student.DepartmentName,
                Phone = model.Student.Phone,
                Age = model.Student.Age,
                NameAr = model.Student.NameAr,
                NameEn = model.Student.NameEn,
                DID = model.Student.DID,
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

                var modell = new StudentCreateViewModel
                {
                    Student = new GetStudentOutput(),
                    getListDepartment = _cachedDepartments
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
                NameAr = model.Student.NameAr,
                NameEn = model.Student.NameEn,
                Address = model.Student.Address,
                DID = model.Student.DID,
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

        #endregion
    }
}
