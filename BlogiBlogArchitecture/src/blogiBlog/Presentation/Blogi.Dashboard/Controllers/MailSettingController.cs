using Blogi.Application.Features.MailSettings.Commands.Update;
using Blogi.Application.Features.MailSettings.Queries.Get;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogi.Dashboard.Controllers
{
    [Authorize]
    public class MailSettingController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Home()
        {
            var result = await Mediator.Send(new GetMailSettingQuery());
            if (result.Success)
                return View(result.Data);
            else
            {
                NotifyError(result.Errors);
                return View();
            }
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateMailSettingCommand input)
        {
            var result = await Mediator.Send(input);
            if (result.Success)
            {
                NotifySuccess(result.Message);
                return RedirectToAction("Home", "MailSetting");
            }
            else
            {
                NotifyError(result.Errors);
                return View(result.Data);
            }
        }
    }
}
