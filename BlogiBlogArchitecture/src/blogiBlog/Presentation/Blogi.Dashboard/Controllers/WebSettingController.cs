using Blogi.Application.Features.WebSettings.Commands.Update;
using Blogi.Application.Features.WebSettings.Queries.Get;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogi.Dashboard.Controllers
{
    [Authorize]
    public class WebSettingController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Home()
        {
            var result = await Mediator.Send(new GetWebSettingQuery());
            if (result.Success)
                return View(result.Data);
            else
            {
                NotifyError(result.Errors);
                return View();
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateWebSettingCommand input)
        {
            var result = await Mediator.Send(input);
            if (result.Success)
            {
                NotifySuccess(result.Message);
                return RedirectToAction("Home", "WebSetting");
            }
            else
            {
                NotifyError(result.Errors);
                return RedirectToAction("Home", "WebSetting");
            }
        }
    }
}