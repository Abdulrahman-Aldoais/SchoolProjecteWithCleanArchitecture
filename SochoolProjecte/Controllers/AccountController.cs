
using Core.Application.FormAuth.CookieScheme;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.Application.Features.Auth.Commands.Login;

namespace SchoolProjecte.Controllers
{
    public class AccountController : BaseController
    {

        [AllowAnonymous, HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous, HttpPost]
        public async Task<IActionResult> Login(LoginUserCommand input)
        {
            var result = await Mediator.Send(input);
            if (result.Success)
                return RedirectToAction("Index", "Student");

            NotifyError(result.Errors);
            return View(input);
        }

        [Authorize, HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(AuthDefaults.Scheme);
            return RedirectToAction("Login", "Account");
        }






    }
}