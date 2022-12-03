using Blogi.Application.Features.WebSettings.Queries.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blogi.UI.Components
{
    public class SocialLinks : ViewComponent
    {
        protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        private IMediator? _mediator;


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await Mediator.Send(new GetWebSettingQuery());
            return View(result.Data);
        }
    }
}