﻿using Blogi.Application.Features.Categories.Queries.GetList;
using Blogi.Application.Features.Languages.Queries.Get;
using Blogi.Application.Features.Languages.Queries.GetList;
using Blogi.Application.Features.Posts.Commands.Create;
using Blogi.Application.Features.Posts.Commands.Delete;
using Blogi.Application.Features.Posts.Commands.Update;
using Blogi.Application.Features.Posts.Queries.Get;
using Blogi.Application.Features.Posts.Queries.GetList;
using Blogi.Application.Features.PostsTags.Commands.Create;
using Blogi.Application.Features.PostsTags.Commands.Delete;
using Blogi.Application.Features.PostsTags.Commands.Update;
using Blogi.Application.Features.PostsTags.Queries.Get;
using Blogi.Application.Features.Tags.Queries.GetList;
using Blogi.Dashboard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogi.Dashboard.Controllers
{
    [Authorize]
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
            var categoryList = await Mediator.Send(new GetListCategoryQuery() { LanguageId = GetCurrentLanguageId() });
            var tagList = await Mediator.Send(new GetListTagQuery() { Culture = GetCurrentCulture });
            var model = new PostCreateViewModel
            {
                CategoryList = categoryList.Data,
                TagList = tagList.Data
            };
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostCreateViewModel input)
        {
            #region Byte File Processing
            byte[] fileBytes = null;
            if (input.File is not null)
            {
                using var memoryStream = new MemoryStream();
                input.File.CopyTo(memoryStream);
                fileBytes = memoryStream.ToArray();
            }
            #endregion

            var result = await Mediator.Send(new CreatePostCommand()
            {
                UserId = input.Post.UserId,
                CategoryId = input.Post.CategoryId,
                LanguageId = GetCurrentLanguageId(),
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
                var categoryList = await Mediator.Send(new GetListCategoryQuery());
                var tagList = await Mediator.Send(new GetListTagQuery() { Culture = GetCurrentCulture });
                var model = new PostCreateViewModel
                {
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
                if (!postTagResult.Success)
                {
                    NotifyError(result.Errors);
                    return View();
                }

                NotifySuccess(result.Message);
                return RedirectToAction("Home", "Post");
            }
        }

        [HttpPost]
        public async Task<JsonResult> Delete(DeletePostCommand input)
        {
            var postTagDelete = await Mediator.Send(new DeletePostTagCommand() { PostId = input.Id });
            if (!postTagDelete.Success)
                return Json(new { data = postTagDelete.Errors });

            var result = await Mediator.Send(input);
            return Json(new { data = result });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(GetPostQuery input)
        {
            if (input.Id == 0) return RedirectToAction("Home", "Post");

            var result = await Mediator.Send(input);           
            var categoryList = await Mediator.Send(new GetListCategoryQuery() { LanguageId = GetCurrentLanguageId() });
            var tagList = await Mediator.Send(new GetListTagQuery() { Culture = GetCurrentCulture });
            var tagIds = await Mediator.Send(new GetPostTagQuery() { PostId = input.Id });
            var model = new PostEditViewModel();

            if (result.Success)
            {
                model.Post = result.Data;
                model.CategoryList = categoryList.Data;
                model.TagList = tagList.Data;
                model.TagIds = tagIds.Data;
                return View(model);
            }
            else
            {
                NotifyError(result.Errors);
                return View(model);
            }

        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PostEditViewModel input)
        {
            #region Byte File Processing
            byte[] fileBytes = null;
            if (input.File is not null)
            {
                using var memoryStream = new MemoryStream();
                input.File.CopyTo(memoryStream);
                fileBytes = memoryStream.ToArray();
            }
            #endregion

            var result = await Mediator.Send(new UpdatePostCommand()
            {
                Id = input.Post.Id,
                UserId = input.Post.UserId,
                LanguageId = GetCurrentLanguageId(),
                CategoryId = input.Post.CategoryId,
                Title = input.Post.Title,
                Content = input.Post.Content,
                Slug = input.Post.Slug,
                Image = fileBytes,
                ImageAlt = input.Post.ImageAlt,
                MetaKeywords = input.Post.MetaKeywords,
                MetaDescription = input.Post.MetaDescription,
                IsPublished = input.Post.IsPublished
            });

            if (result.Success)
            {
                await Mediator.Send(new UpdatePostTagCommand() { PostId = result.Id, TagIds = input.TagIds });

                NotifySuccess(result.Message);
                return RedirectToAction("Home", "Post");
            }
            else
            {
                var categoryList = await Mediator.Send(new GetListCategoryQuery() { LanguageId = GetCurrentLanguageId() });
                var tagList = await Mediator.Send(new GetListTagQuery() { Culture = GetCurrentCulture });
                var tagIds = await Mediator.Send(new GetPostTagQuery() { PostId = input.Post.Id });
                var model = new PostEditViewModel
                {
                    Post = result.Data,
                    CategoryList = categoryList.Data,
                    TagList = tagList.Data,
                    TagIds = tagIds.Data
                };
                NotifyError(result.Errors);
                return View(model);
            }
        }

        [HttpGet]
        public async Task<JsonResult> DataTable()
        {
            var result = await Mediator.Send(new GetListPostQuery() { LanguageId = GetCurrentLanguageId() });
            return Json(new { data = result.Data });
        }
    }
}