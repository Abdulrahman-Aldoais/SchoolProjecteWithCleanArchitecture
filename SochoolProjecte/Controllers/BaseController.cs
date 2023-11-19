using Core.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using School.Domain.Resources;
using SchoolProjecte.Models;
using System.Net;

namespace SchoolProjecte.Controllers
{
    public class BaseController : Controller
    {
        protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        private IMediator? _mediator;


        #region Actions


        public async Task<IActionResult> NewResult<T>(
            BaseCommandResponse<T> response, Func<IActionResult> value)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    NotifySuccess(SharedResourcesKeys.Success); // نص الرسالة في حالة النجاح
                    return await Task.FromResult(value.Invoke()); // استخدام Task.FromResult للحصول على Task<IActionResult>
                case HttpStatusCode.Created:
                    NotifySuccess(SharedResourcesKeys.Created); // تعديل هنا لنص الرسالة في حالة النجاح
                    return await Task.FromResult(value.Invoke()); // استخدام Task.FromResult للحصول على Task<IActionResult>
                case HttpStatusCode.Unauthorized:
                    NotifyError(new List<string> { SharedResourcesKeys.UnAuthorized }); // تعديل هنا لنص الرسالة في حالة الخطأ
                    return await Task.FromResult(value.Invoke());
                case HttpStatusCode.BadRequest:
                    NotifyError(new List<string> { "Error message" }); // تعديل هنا لنص الرسالة في حالة الخطأ
                    return await Task.FromResult(value.Invoke());
                case HttpStatusCode.NotFound:
                    NotifyError(new List<string> { "Error message" }); // تعديل هنا لنص الرسالة في حالة الخطأ
                    return await Task.FromResult(value.Invoke());
                case HttpStatusCode.Accepted:
                    NotifySuccess("Success message"); // تعديل هنا لنص الرسالة في حالة النجاح
                    return await Task.FromResult(value.Invoke());
                case HttpStatusCode.UnprocessableEntity:
                    NotifyError(new List<string> { "Error message" }); // تعديل هنا لنص الرسالة في حالة الخطأ
                    return await Task.FromResult(value.Invoke());
                default:
                    NotifyError(new List<string> { "Error message" }); // تعديل هنا لنص الرسالة في حالة الخطأ
                    return await Task.FromResult(value.Invoke()); // استخدام Task.FromResult للحصول على Task<IActionResult>
            }
        }

        #endregion

        public void NotifySuccess(string successMessage)
        {
            var msg = new
            {
                message = successMessage,
                title = "School",
                icon = NotificationType.success.ToString(),
                type = NotificationType.success.ToString(),
                provider = GetProvider()
            };

            TempData["Message"] = JsonConvert.SerializeObject(msg);
        }

        public void NotifyError(List<string> errorMessage)
        {
            var msg = new
            {
                message = JsonConvert.SerializeObject(errorMessage),
                title = "School",
                icon = NotificationType.error.ToString(),
                type = NotificationType.error.ToString(),
                provider = GetProvider()
            };

            TempData["Message"] = JsonConvert.SerializeObject(msg);
        }

        private string GetProvider()
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();

            var value = configuration["NotificationProvider"];

            return value;
        }
    }
}
