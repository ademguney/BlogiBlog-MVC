using Blogi.Application.Features.Abouts.Queries.Get;
using Blogi.Application.Features.Contacts.Queries.Get;
using Blogi.Application.Features.WebSettings.Queries.Get;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace Blogi.UI.Controllers
{
    public class HomeController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await Mediator.Send(new GetWebSettingQuery());
            return View(result.Data);
        }

        [HttpGet]
        public async Task<IActionResult> About()
        {
            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;
            var result = await Mediator.Send(new GetAboutQuery() { Culture = currentCulture });
            return View(result.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Contact()
        {
            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;
            var result = await Mediator.Send(new GetContactQuery() { Culture = currentCulture });
            return View(result.Data);
        }
         

        [HttpPost]
        public IActionResult ChangeLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddDays(7)
                }
            );

            return LocalRedirect(returnUrl);
        }
    }
}