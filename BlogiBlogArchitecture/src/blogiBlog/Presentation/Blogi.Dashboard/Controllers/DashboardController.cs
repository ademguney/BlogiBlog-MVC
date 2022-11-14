using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogi.Dashboard.Controllers
{
    [Authorize]
    public class DashboardController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Home()
        {

            return View();
        }
    }
}