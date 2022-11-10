using Blogi.Application.Features.Categories.Queries.GetList;
using Blogi.Application.Features.Languages.Queries.GetList;
using Blogi.Application.Features.Posts.Commands;
using Blogi.Application.Features.Posts.Queries.GetList;
using Blogi.Application.Features.PostsTags.Commands.Create;
using Blogi.Application.Features.Tags.Queries.GetList;
using Blogi.Dashboard.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blogi.Dashboard.Controllers
{
    public class PostController : BaseController
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
            var categoryList = await Mediator.Send(new GetListCategoryQuery());
            var tagList = await Mediator.Send(new GetListTagQuery());
            var model = new PostCreateViewModel
            {
                LanguageList = languageList.Data,
                CategoryList = categoryList.Data,
                TagList = tagList.Data
            };
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostCreateViewModel input)
        {

            byte[] fileBytes = null;
            if (input.File is not null)
            {
                using var memoryStream = new MemoryStream();
                input.File.CopyTo(memoryStream);
                fileBytes = memoryStream.ToArray();
            }

            var result = await Mediator.Send(new CreatePostCommand()
            {
                UserId = 1,
                CategoryId = input.Post.CategoryId,
                LanguageId = input.Post.LanguageId,
                Title = input.Post.Title,
                Content = input.Post.Content,
                Image = fileBytes,
                ImageAlt = input.Post.ImageAlt,
                IsPublished = input.Post.IsPublished,
                MetaDescription = input.Post.MetaDescription,
                MetaKeywords = input.Post.MetaKeywords,
                Slug = input.Post.Slug
            });
            if (!result.Success)
            {
                var languageList = await Mediator.Send(new GetListLanguageQuery());
                var categoryList = await Mediator.Send(new GetListCategoryQuery());
                var tagList = await Mediator.Send(new GetListTagQuery());
                var model = new PostCreateViewModel
                {
                    LanguageList = languageList.Data,
                    CategoryList = categoryList.Data,
                    TagList = tagList.Data,
                    Post = input.Post,
                    TagIds = input.TagIds,
                    File = input.File
                };
                NotifyError(result.Errors);
                return View(model);
            }
            else
            {
                var postTagResult = await Mediator.Send(new CreatePostTagCommand() { PostId = result.Id, TagIds = input.TagIds });
                if(!postTagResult.Success)
                {
                    NotifyError(result.Errors);
                    return View();
                }

                NotifySuccess(result.Message);
                return RedirectToAction("Home", "Post");
            }            
        }

        [HttpGet]
        public async Task<JsonResult> DataTable()
        {
            var result = await Mediator.Send(new GetListPostQuery());
            return Json(new { data = result.Data });
        }
    }
}
