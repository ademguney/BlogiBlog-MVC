using Blogi.Application.Features.Comment.Queries.Get;
using Blogi.Application.Features.Comment.Queries.GetList;
using Microsoft.AspNetCore.Mvc;

namespace Blogi.Dashboard.Controllers
{
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


        [HttpGet]
        public async Task<JsonResult> DataTable()
        {
            var result = await Mediator.Send(new GetListCommentQuery());
            return Json(new { data = result.Data });
        }
    }
}
