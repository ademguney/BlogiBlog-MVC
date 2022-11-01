using Blogi.Application.Features.Tags.Commands.Create;
using Blogi.Application.Features.Tags.Commands.Delete;
using Blogi.Application.Features.Tags.Commands.Update;
using Blogi.Application.Features.Tags.Queries.Get;
using Blogi.Application.Features.Tags.Queries.GetList;
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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTagCommand input)
        {
            var result = await Mediator.Send(input);
            if (result.Success)
            {
                NotifySuccess(result.Message);
                return RedirectToAction("Home", "Tag");
            }
            else
            {
                NotifyError(result.Errors);
                return View(input);
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
            if (result.Success)
                return View(result.Data);
            else
            {
                NotifyError(result.Errors);
                return RedirectToAction("Home", "Tag");
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateTagCommand input)
        {
            var result = await Mediator.Send(input);
            if (result.Success)
            {
                NotifySuccess(result.Message);
                return RedirectToAction("Home", "Tag");
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
            var result = await Mediator.Send(new GetListTagQuery());
            return Json(new { data = result.Data });
        }
    }
}
