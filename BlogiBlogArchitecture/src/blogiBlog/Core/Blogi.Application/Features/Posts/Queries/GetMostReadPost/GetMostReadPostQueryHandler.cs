using Blogi.Application.Features.Posts.Dtos.GetMostReadPost;

namespace Blogi.Application.Features.Posts.Queries.GetMostReadPost
{
	public class GetMostReadPostQueryHandler : IRequestHandler<GetMostReadPostQuery, BaseCommandResponse<List<GetMostReadPostOutput>>>
	{
		private readonly IPostService _postService;

		public GetMostReadPostQueryHandler(IPostService postService)
		{
			_postService = postService;
		}

		public async Task<BaseCommandResponse<List<GetMostReadPostOutput>>> Handle(GetMostReadPostQuery request, CancellationToken cancellationToken)
		{
			var response=new BaseCommandResponse<List<GetMostReadPostOutput>>();
			var result = await _postService.GetMostReadAsync();

			response.Data = result;
			response.Success = true;
			response.Errors = null;

			return response;

		}
	}
}