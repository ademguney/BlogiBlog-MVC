using Blogi.Application.Features.Languages.Commands.Create;
using Blogi.Application.Features.Languages.Commands.Delete;
using Blogi.Application.Features.Languages.Commands.Update;
using Blogi.Application.Features.Languages.Queries.Get;
using Blogi.Application.Features.Languages.Queries.GetList;
using Microsoft.AspNetCore.Mvc;

namespace Blogi.Dashboard.Controllers
{
    public class LanguageController : BaseController
    {

        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateLanguageCommand input)
        {
            var result = await Mediator.Send(input);
            if (result.Success)
            {
                NotifySuccess(result.Message);
                return RedirectToAction("Home", "Language");
            }
            else
            {
                NotifyError(result.Errors);
                return View(input);
            }
        }

        [HttpPost]
        public async Task<JsonResult> Delete(DeleteLanguageCommand input)
        {
            var result = await Mediator.Send(input);
            return Json(new { data = result });

        }

        [HttpGet]
        public async Task<IActionResult> Edit(GetLanguageQuery input)
        {
            var result = await Mediator.Send(input);
            if (result.Success)
                return View(result.Data);
            else
            {
                NotifyError(result.Errors);
                return RedirectToAction("Home", "Language");
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateLanguageCommand input)
        {
            var result = await Mediator.Send(input);
            if (result.Success)
            {
                NotifySuccess(result.Message);
                return RedirectToAction("Home", "Language");
            }
            else
            {
                NotifyError(result.Errors);
                return View(result.Data);
            }
        }

        [HttpGet]
        public async Task<JsonResult> DataTable()
        {
            var result = await Mediator.Send(new GetListLanguageQuery());
            return Json(new { data = result.Data });
        }
    }
}
