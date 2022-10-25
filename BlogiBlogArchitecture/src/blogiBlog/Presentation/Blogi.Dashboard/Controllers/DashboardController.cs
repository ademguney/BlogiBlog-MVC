using Blogi.Application.Features.Languages.Queries.GetList;
using Microsoft.AspNetCore.Mvc;

namespace Blogi.Dashboard.Controllers
{
    public class DashboardController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Home()
        {
           
            return View();
        }

        
    }
}
