using Blogi.Application.Services.TagService;
using Microsoft.AspNetCore.Mvc;

namespace Blogi.UI.Components
{
    public class TagMenu : ViewComponent
    {
        private readonly ITagService _tagService;

        public TagMenu(ITagService tagService)
        {
            _tagService = tagService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;
            var result = await _tagService.GetListAsync(currentCulture);
            return View(result);
        }
    }
}