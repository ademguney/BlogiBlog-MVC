using Blogi.Application.Features.Users.Commands.Update;
using Blogi.Application.Features.Users.Queries.Get;
using Blogi.Dashboard.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blogi.Dashboard.Controllers
{
    public class AccountController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var result = await Mediator.Send(new GetUserQuery() { Id = 1 });
            var model = new ProfileCreateViewModel
            {
                User = result.Data
            };
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
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