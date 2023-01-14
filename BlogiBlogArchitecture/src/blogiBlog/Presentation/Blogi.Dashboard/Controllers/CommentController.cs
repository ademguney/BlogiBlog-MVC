
using Blogi.Application.Features.Comments.Commands.Delete;
using Blogi.Application.Features.Comments.Queries.Get;
using Blogi.Application.Features.Comments.Queries.GetList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogi.Dashboard.Controllers
{
    [Authorize]
    public class CommentController : BaseController
    {
        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Answer(GetCommentQuery input)
        {
            var result = await Mediator.Send(input);
            return View(result.Data);

        }

        [HttpPost]
        public async Task<JsonResult> Delete(DeleteCommentCommand input)
        {
            var result = await Mediator.Send(input);
            return Json(new { data = result });

        }

        [HttpGet]
        public async Task<JsonResult> DataTable()
        {
            var result = await Mediator.Send(new GetListCommentQuery());
            return Json(new { data = result.Data });
        }
    }
}
