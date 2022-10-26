using Blogi.Application.Features.StringResources.Queries.GitList;
using Microsoft.AspNetCore.Mvc;

namespace Blogi.Dashboard.Controllers
{
    public class StringResourceController : BaseController
    {
        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> DataTable()
        {
            var result = await Mediator.Send(new GetListStringResourceQuery());
            return Json(new { data = result.Data });
        }
    }
}
