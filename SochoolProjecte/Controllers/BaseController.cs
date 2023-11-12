﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SchoolProjecte.Models;

namespace SchoolProjecte.Controllers
{
    public class BaseController : Controller
    {
        protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        private IMediator? _mediator;


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
