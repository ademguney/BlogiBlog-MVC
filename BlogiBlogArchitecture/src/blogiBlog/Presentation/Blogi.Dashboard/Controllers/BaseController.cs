using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blogi.Dashboard.Controllers
{
    public class BaseController : Controller
    {
        protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        private IMediator? _mediator;
    }
}
