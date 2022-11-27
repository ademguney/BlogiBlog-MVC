using Blogi.Application.Features.Categories.Commands.Create;
using Blogi.Application.Features.Categories.Commands.Delete;
using Blogi.Application.Features.Categories.Commands.Update;
using Blogi.Application.Features.Categories.Queries.Get;
using Blogi.Application.Features.Categories.Queries.GetList;
using Blogi.Application.Features.Languages.Queries.GetList;
using Blogi.Dashboard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogi.Dashboard.Controllers
{
    [Authorize]
    public class CategoryController : BaseController
    {
        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var languageList = await Mediator.Send(new GetListLanguageQuery());
            var model = new CategoryCreateViewModel
            {
                LanguageList = languageList.Data,
                CategoryCommand = new CreateCategoryCommand()
            };
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateViewModel input)
        {
            var result = await Mediator.Send(input.CategoryCommand);
            if (result.Success)
            {
                NotifySuccess(result.Message);
                return RedirectToAction("Home", "Category");
            }
            else
            {
                var languageList = await Mediator.Send(new GetListLanguageQuery());
                var model = new CategoryCreateViewModel
                {
                    LanguageList = languageList.Data,
                    CategoryCommand = input.CategoryCommand
                };

                NotifyError(result.Errors);
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(GetCategoryQuery input)
        {
            var result = await Mediator.Send(input);
            var languageList = await Mediator.Send(new GetListLanguageQuery());
            var model = new CategoryEditViewModel();

            if (result.Success)
            {
                model.Category = result.Data;
                model.LanguageList = languageList.Data;
                return View(model);
            }
            else
            {
                NotifyError(result.Errors);
                return View(model);
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoryEditViewModel input)
        {
            var result = await Mediator.Send(new UpdateCategoryCommand
            {
                Id = input.Category.Id,
                LanguageId = input.Category.LanguageId,
                Name = input.Category.Name,
                Description = input.Category.Description,
                Slug = input.Category.Slug
            });

            if (result.Success)
            {
                NotifySuccess(result.Message);
                return RedirectToAction("Home", "Category");
            }
            else
            {
                var languageList = await Mediator.Send(new GetListLanguageQuery());
                var model = new CategoryEditViewModel
                {
                    LanguageList = languageList.Data,
                    Category = input.Category
                };

                NotifyError(result.Errors);
                return View(model);
            }
        }

        [HttpPost]
        public async Task<JsonResult> Delete(DeleteCategoryCommand input)
        {
            var result = await Mediator.Send(input);
            return Json(new { data = result });

        }

        [HttpGet]
        public async Task<JsonResult> DataTable()
        {
            var result = await Mediator.Send(new GetListCategoryQuery());
            return Json(new { data = result.Data });
        }
    }
}
