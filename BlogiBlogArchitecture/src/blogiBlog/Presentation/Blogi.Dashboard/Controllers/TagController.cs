using Blogi.Application.Features.Languages.Queries.GetList;
using Blogi.Application.Features.Tags.Commands.Create;
using Blogi.Application.Features.Tags.Commands.Delete;
using Blogi.Application.Features.Tags.Commands.Update;
using Blogi.Application.Features.Tags.Queries.Get;
using Blogi.Application.Features.Tags.Queries.GetList;
using Blogi.Dashboard.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blogi.Dashboard.Controllers
{
    public class TagController : BaseController
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
            var model = new TagCreateViewModel
            {
                LanguageList = languageList.Data,
                TagCommand = new CreateTagCommand()
            };
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TagCreateViewModel input)
        {
            var result = await Mediator.Send(input.TagCommand);
            if (result.Success)
            {
                NotifySuccess(result.Message);
                return RedirectToAction("Home", "Tag");
            }
            else
            {
                var languageList = await Mediator.Send(new GetListLanguageQuery());
                var model = new TagCreateViewModel
                {
                    LanguageList = languageList.Data,
                    TagCommand = input.TagCommand
                };

                NotifyError(result.Errors);
                return View(model);
            }
        }

        [HttpPost]
        public async Task<JsonResult> Delete(DeleteTagCommand input)
        {
            var result = await Mediator.Send(input);
            return Json(new { data = result });

        }

        [HttpGet]
        public async Task<IActionResult> Edit(GetTagQuery input)
        {
            var result = await Mediator.Send(input);
            var languageList = await Mediator.Send(new GetListLanguageQuery());
            var model = new TagEditViewModel();

            if (result.Success)
            {
                model.Tag = result.Data;
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
        public async Task<IActionResult> Edit(TagEditViewModel input)
        {
            var result = await Mediator.Send(new UpdateTagCommand { Id = input.Tag.Id, LanguageId = input.Tag.LanguageId, Name = input.Tag.Name });
            if (result.Success)
            {
                NotifySuccess(result.Message);
                return RedirectToAction("Home", "Tag");
            }
            else
            {
                var languageList = await Mediator.Send(new GetListLanguageQuery());
                var model = new TagEditViewModel
                {
                    LanguageList = languageList.Data,
                    Tag = input.Tag
                };

                NotifyError(result.Errors);
                return View(model);
            }
        }

        [HttpGet]
        public async Task<JsonResult> DataTable()
        {
            var result = await Mediator.Send(new GetListTagQuery());
            return Json(new { data = result.Data });
        }
    }
}
