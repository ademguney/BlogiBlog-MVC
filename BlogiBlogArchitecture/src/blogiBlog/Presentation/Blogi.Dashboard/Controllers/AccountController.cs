using Blogi.Application.Features.Auth.Commands.ForgotPassword;
using Blogi.Application.Features.Auth.Commands.Login;
using Blogi.Application.Features.Users.Commands.Update;
using Blogi.Application.Features.Users.Queries.Get;
using Blogi.Dashboard.Models;
using Core.Application.FormAuth.CookieScheme;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogi.Dashboard.Controllers
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
                return RedirectToAction("Home", "Dashboard");

            NotifyError(result.Errors);
            return View(input);
        }

        [Authorize, HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(AuthDefaults.Scheme);
            return RedirectToAction("Login", "Account");
        }

        [AllowAnonymous, HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [AllowAnonymous, HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordUserCommand input)
        {
            var result = await Mediator.Send(input);
            if (!result.Success)
            {
                NotifyError(result.Errors);
                return View();
            }
            NotifySuccess(result.Message);
            return RedirectToAction("Login","Account");
        }

        [Authorize, HttpGet]
        public async Task<IActionResult> Profile(int id)
        {
            var result = await Mediator.Send(new GetUserQuery() { Id = id });
            var model = new ProfileCreateViewModel
            {
                User = result.Data
            };
            return View(model);
        }

        [Authorize, HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Profile(ProfileCreateViewModel input)
        {
            byte[] fileBytes = null;
            if (input.File is not null)
            {
                using var memoryStream = new MemoryStream();
                input.File.CopyTo(memoryStream);
                fileBytes = memoryStream.ToArray();
            }

            var result = await Mediator.Send(new UpdateUserCommand()
            {
                Id = input.User.Id,
                Name = input.User.Name,
                Surname = input.User.Surname,
                Email = input.User.Email,
                Password = input.User.Password,
                Photo = fileBytes

            });
            if (result.Success)
            {
                NotifySuccess(result.Message);
                return RedirectToAction("Profile", "Account");
            }

            NotifyError(result.Errors);
            return View(input);
        }
    }
}