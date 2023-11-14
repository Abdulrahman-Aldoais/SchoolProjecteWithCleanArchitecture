﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using School.Application.Repositories.UserRepository;
using School.Domain.Entities;

namespace School.Application.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserWriteRepository _userWriteRepository;

        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(IUserWriteRepository userWriteRepository,
            IHttpContextAccessor httpContextAccessor,
            UserManager<User> userManager)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _userWriteRepository = userWriteRepository;
        }
        public async Task<string> AddUserAsync(User user, string password)
        {

            try
            {
                //if Email is Exist
                var existUser = await _userManager.FindByEmailAsync(user.Email);
                //email is Exist
                if (existUser != null) return "EmailIsExist";

                //if username is Exist
                var userByUserName = await _userManager.FindByNameAsync(user.UserName);
                //username is Exist
                if (userByUserName != null) return "UserNameIsExist";
                //Create
                var createResult = await _userManager.CreateAsync(user, password);
                //Failed
                if (!createResult.Succeeded)
                    return string.Join(",", createResult.Errors.Select(x => x.Description).ToList());

                await _userManager.AddToRoleAsync(user, "User");

                //Send Confirm Email
                //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                //var resquestAccessor = _httpContextAccessor.HttpContext.Request;
                //var returnUrl = resquestAccessor.Scheme + "://" + resquestAccessor.Host + _urlHelper.Action("ConfirmEmail", "Authentication", new { userId = user.Id, code = code });
                //var message = $"To Confirm Email Click Link: <a href='{returnUrl}'></a>";
                ////$"/Api/V1/Authentication/ConfirmEmail?userId={user.Id}&code={code}";
                ////message or body
                //await _emailsService.SendEmail(user.Email, message, "ConFirm Email");

                //await trans.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                //await trans.RollbackAsync();
                return "Failed";
            }

        }
    }
}
