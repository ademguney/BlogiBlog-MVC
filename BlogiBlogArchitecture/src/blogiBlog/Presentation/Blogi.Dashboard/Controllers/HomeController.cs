using Microsoft.AspNetCore.Mvc;

namespace Blogi.Dashboard.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

       
    }
}