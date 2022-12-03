using Blogi.Application.Features.Abouts.Commands.Create;
using Blogi.Application.Features.Abouts.Commands.Delete;
using Blogi.Application.Features.Abouts.Commands.Update;
using Blogi.Application.Features.Abouts.Queries.Get;
using Blogi.Application.Features.Abouts.Queries.GetList;
using Blogi.Application.Features.Languages.Queries.GetList;
using Blogi.Dashboard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogi.Dashboard.Controllers
{
    [Authorize]
    public class AboutController : BaseController
    {
        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var languageList = await Mediator.Send(new GetListLanguageQuery());
            var model = new AboutCreateViewModel
            {
                LanguageList = languageList.Data,
                AboutCommand = new CreateAboutCommand()
            };
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AboutCreateViewModel input)
        {
            var result = await Mediator.Send(input.AboutCommand);
            if (result.Success)
            {
                NotifySuccess(result.Message);
                return RedirectToAction("Home", "About");
            }
            else
            {
                var languageList = await Mediator.Send(new GetListLanguageQuery());
                var model = new AboutCreateViewModel
                {
                    LanguageList = languageList.Data,
                    AboutCommand = input.AboutCommand
                };

                NotifyError(result.Errors);
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(GetAboutQuery input)
        {
            var result = await Mediator.Send(input);
            var languageList = await Mediator.Send(new GetListLanguageQuery());
            var model = new AboutEditViewModel();

            if (result.Success)
            {
                model.About = result.Data;
                model.LanguageList = languageList.Data;
                return View(model);
            }
            else
            {
                NotifyError(result.Errors);
                return View(model);
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AboutEditViewModel input)
        {
            var result = await Mediator.Send(new UpdateAboutCommand
            {
                Id = input.About.Id,
                Content = input.About.Content,              
                LanguageId = input.About.LanguageId,               
                MetaDescription = input.About.MetaDescription,
                MetaKeywords = input.About.MetaKeywords,             
                Slug = input.About.Slug,
                Title = input.About.Title
            });
            if (result.Success)
            {
                NotifySuccess(result.Message);
                return RedirectToAction("Home", "About");
            }
            else
            {
                var languageList = await Mediator.Send(new GetListLanguageQuery());
                var model = new AboutEditViewModel
                {
                    LanguageList = languageList.Data,
                    About = input.About
                };

                NotifyError(result.Errors);
                return View(model);
            }
        }

        [HttpPost]
        public async Task<JsonResult> Delete(DeleteAboutCommand input)
        {
            var result = await Mediator.Send(input);
            return Json(new { data = result });

        }

        [HttpGet]
        public async Task<JsonResult> DataTable()
        {
            var result = await Mediator.Send(new GetListAboutQuery());
            return Json(new { data = result.Data });
        }
    }
}