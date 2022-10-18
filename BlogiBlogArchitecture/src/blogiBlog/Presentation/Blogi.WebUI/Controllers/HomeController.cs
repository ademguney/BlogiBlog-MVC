using Microsoft.AspNetCore.Mvc;

namespace Blogi.WebUI.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
       
    }
}