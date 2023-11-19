using Microsoft.AspNetCore.Mvc;
using School.Application.Features.User.Command.Create;
using School.Application.Features.User.Dtos.Get;
using School.Application.Features.User.Queries.GetList;

namespace SchoolProjecte.Controllers
{
    public class UserController : BaseController
    {



        public async Task<IActionResult> Index()
        {
            var getAllUser = await Mediator.Send(new GetUserListQuery());

            return View(getAllUser.Data);
        }
        [HttpGet]
        public async Task<IActionResult> AddUser()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        [Route("user/addUser/")]
        public async Task<IActionResult> AddUser(GetUserOutput getUserOutput)
        {

            var result = await Mediator.Send(new CreateUserCommand
            {
                FullName = getUserOutput.FullName,
                Address = getUserOutput.Address,
                Country = getUserOutput.Country,
                Email = getUserOutput.Email,
                Password = getUserOutput.Password,
                UserName = getUserOutput.UserName,
                Task = getUserOutput.Task
            });
            return await NewResult(result, () =>
            {
                if (result.Success)
                {
                    //TempData["success"] = result.Message;
                    NotifySuccess(result.Message);
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    //TempData["error"] = result.Message;
                    NotifyError(result.Errors);
                    return View(getUserOutput);
                }
            });


        }
    }
}
