using Blogi.Application.Features.Languages.Queries.GetList;
using Blogi.Application.Features.StringResources.Commands.Create;
using Blogi.Application.Features.StringResources.Commands.Delete;
using Blogi.Application.Features.StringResources.Commands.Update;
using Blogi.Application.Features.StringResources.Queries.Get;
using Blogi.Application.Features.StringResources.Queries.GitList;
using Blogi.Dashboard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogi.Dashboard.Controllers
{
    [Authorize]
    public class StringResourceController : BaseController
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
            var model = new StringResourceCreateViewModel
            {
                LanguageList = languageList.Data,
                StringResourceCommand = new CreateStringResourceCommand()
            };
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StringResourceCreateViewModel input)
        {
            var result = await Mediator.Send(input.StringResourceCommand);          
            if (result.Success)
            {
                NotifySuccess(result.Message);
                return RedirectToAction("Home", "StringResource");
            }
            else
            {
                var languageList = await Mediator.Send(new GetListLanguageQuery());
                var model = new StringResourceCreateViewModel
                {
                    LanguageList = languageList.Data,
                    StringResourceCommand = input.StringResourceCommand
                };
                NotifyError(result.Errors);
                return View(model);
            }
        }

        [HttpPost]
        public async Task<JsonResult> Delete(DeleteStringResourceCommand input)
        {
            var result = await Mediator.Send(input);
            return Json(new { data = result });

        }

        [HttpGet]
        public async Task<IActionResult> Edit(GetStringResourceQuery input)
        {
            var result = await Mediator.Send(input);
            var languageList = await Mediator.Send(new GetListLanguageQuery());
            var model = new StringResourceEditViewModel();

            if (result.Success)
            {
                model.StringResource = result.Data;
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
        public async Task<IActionResult> Edit(StringResourceEditViewModel input)
        {
            var result = await Mediator.Send(new UpdateStringResourceCommand
            {
                Id = input.StringResource.Id,
                LanguageId = input.StringResource.LanguageId,
                Key = input.StringResource.Key,
                Value = input.StringResource.Value
            });

            if (result.Success)
            {
                NotifySuccess(result.Message);
                return RedirectToAction("Home", "StringResource");
            }
            else
            {
                var languageList = await Mediator.Send(new GetListLanguageQuery());
                var model = new StringResourceEditViewModel
                {
                    LanguageList = languageList.Data,
                    StringResource = input.StringResource
                };

                NotifyError(result.Errors);
                return View(model);
            }
        }

        [HttpGet]
        public async Task<JsonResult> DataTable()
        {
            var result = await Mediator.Send(new GetListStringResourceQuery());
            return Json(new { data = result.Data });
        }
    }
}
