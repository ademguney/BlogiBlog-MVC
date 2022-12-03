using Blogi.Application.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;

namespace Blogi.UI.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategoryMenu(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;
            var result = await _categoryService.GetListAsync(currentCulture);
            return View(result);
        }
    }
}