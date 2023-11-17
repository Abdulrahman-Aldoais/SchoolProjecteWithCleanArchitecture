using Microsoft.AspNetCore.Mvc;
using School.Application.Features.User.Command.Create;
using School.Application.Features.User.Dtos.Get;

namespace SchoolProjecte.Controllers
{
    public class UserController : BaseController
    {



        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AddUser()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser(GetUserOutput getUserOutput)
        {
            var addUserModel = new CreateUserCommand
            {
                FullName = getUserOutput.FullName,
                Address = getUserOutput.Address,
                Country = getUserOutput.Country,
                Email = getUserOutput.Email,
                Password = getUserOutput.Password,
                UserName = getUserOutput.UserName,
                Task = getUserOutput.Task
            };

            var result = await Mediator.Send(addUserModel);
            if (result.Success)
            {
                NotifySuccess(result.Message);
                return RedirectToAction("Index", "User");
            }
            else
            {
                NotifyError(result.Errors);
                return View(getUserOutput);
            }


        }
    }
}
