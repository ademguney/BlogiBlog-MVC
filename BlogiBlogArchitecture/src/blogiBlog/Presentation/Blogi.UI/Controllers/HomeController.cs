using Blogi.Application.Features.Abouts.Queries.Get;
using Blogi.Application.Features.Categories.Queries.GetListBlogCategory;
using Blogi.Application.Features.Comments.Commands.Create;
using Blogi.Application.Features.Contacts.Queries.Get;
using Blogi.Application.Features.MailSends.Commands.ContactMailSend;
using Blogi.Application.Features.Posts.Queries.GetBlogPost;
using Blogi.Application.Features.Posts.Queries.GetListBlogPost;
using Blogi.Application.Features.PostsTags.Queries.GetListBlogPostTag;
using Blogi.Application.Features.WebSettings.Queries.Get;
using Blogi.UI.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Blogi.UI.Controllers
{
    public class HomeController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> Index(string searchText, int pageNo = 1, int pageSize = 9)
        {

            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;
            var blogList = await Mediator.Send(new GetListBlogPostQuery() { Culture = currentCulture, SearchText = searchText });
            var webSettings = await Mediator.Send(new GetWebSettingQuery());
            var viewModel = new HomeIndexViewModel
            {
                WebSettings = webSettings.Data,
                BlogPost = blogList.Data.ToPagedList(pageNo, pageSize)
            };

            return View(viewModel);
        }

        [HttpGet]
        [Route("{title}-{id}")]
        public async Task<IActionResult> Post(int id)
        {
            var result = await Mediator.Send(new GetBlogPostQuery() { Id = id });
            return View(result.Data);
        }

        [HttpPost]
        public async Task<JsonResult> Comment(CreateCommentCommand input)
        {
            var result = await Mediator.Send(input);
            return Json(new { data = result });
        }


        [HttpGet]
        [Route("category/{categoryName}-{id}")]
        public async Task<IActionResult> Category(int id, int pageNo = 1, int pageSize = 9)
        {
            var result = await Mediator.Send(new GetListBlogCategoryQuery() { Id = id });
            var webSettings = await Mediator.Send(new GetWebSettingQuery());
            var viewModel = new CategoryViewModel
            {
                WebSettings = webSettings.Data,
                BlogPost = result.Data.ToPagedList(pageNo, pageSize)
            };

            return View(viewModel);
        }

        [HttpGet]
        [Route("tag/{tagName}-{id}")]
        public async Task<IActionResult> Tag(int id, int pageNo = 1, int pageSize = 9)
        {
            var result = await Mediator.Send(new GetListBlogPostTagQuery() { TagId = id });
            var webSettings = await Mediator.Send(new GetWebSettingQuery());
            var viewModel = new TagViewModel
            {
                WebSettings = webSettings.Data,
                BlogPost = result.Data.ToPagedList(pageNo, pageSize)
            };

            return View(viewModel);
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
        public async Task<JsonResult> SendMail(ContactMailSendCommand input)
        {
            var result = await Mediator.Send(input);
            return Json(new { data = result.Message });
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