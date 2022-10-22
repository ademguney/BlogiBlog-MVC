using Blogi.Application.Features.Languages.Commands.Create;
using Blogi.Application.Features.Languages.Queries.Get;
using Blogi.Application.Features.Languages.Queries.GetList;
using Microsoft.AspNetCore.Mvc;

namespace Blogi.Dashboard.Controllers
{
    public class HomeController : BaseController
    {
        
        public async Task<IActionResult> Index()
        {
            var result = await Mediator.Send(new CreateLanguageCommand() { Name= "Türkçe", Culture="aa"});
            return View();
        }

       
    }
}