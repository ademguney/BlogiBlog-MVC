using Blogi.Application.Features.Categories.Queries.GetCategoryCount;
using Blogi.Application.Features.Comments.Queries.GetCommentCount;
using Blogi.Application.Features.Posts.Queries.GetMostReadPost;
using Blogi.Application.Features.Posts.Queries.GetPostCount;
using Blogi.Application.Features.Tags.Queries.GetTagCount;
using Blogi.Dashboard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogi.Dashboard.Controllers
{
	[Authorize]
	public class DashboardController : BaseController
	{
		[HttpGet]
		public async Task<IActionResult> Home()
		{
			var articleCount = await Mediator.Send(new GetPostCountQuery());
			var categoryCount = await Mediator.Send(new GetCategoryCountQuery());
			var commentCount = await Mediator.Send(new GetCommentCountQuery());
			var tagCount = await Mediator.Send(new GetTagCountQuery());

			var model = new DashboardHomeViewModel
			{
				CountOfArticle = articleCount.Data,
				CountOfCategory = categoryCount.Data,
				CountOfComment = commentCount.Data,
				CountOfTag = tagCount.Data
			};
			return View(model);
		}

		[HttpGet]
		public async Task<JsonResult> GetMostRead()
		{
			var result = await Mediator.Send(new GetMostReadPostQuery());
			return Json(new { result.Data });
		}
	}
}