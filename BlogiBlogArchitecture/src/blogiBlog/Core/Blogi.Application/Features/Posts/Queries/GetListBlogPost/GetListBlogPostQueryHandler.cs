using Blogi.Application.Features.Posts.Dtos.GetListBlogPost;

namespace Blogi.Application.Features.Posts.Queries.GetListBlogPost
{
    public class GetListBlogPostQueryHandler : IRequestHandler<GetListBlogPostQuery, BaseCommandResponse<List<GetListBlogPostOutput>>>
    {
        private readonly IPostService _postService;

        public GetListBlogPostQueryHandler(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<BaseCommandResponse<List<GetListBlogPostOutput>>> Handle(GetListBlogPostQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<List<GetListBlogPostOutput>>();
            var result = await _postService.GetListBlogPostAsync(request.Culture);
            if (!result.Any())
            {
                response.Success = false;
                response.Message = PostMessages.GetListNotExists;
                response.Errors = null;
                response.Data = new List<GetListBlogPostOutput>();
            }
            else
            {
                response.Data = result;
                response.Success = true;
                response.Message = PostMessages.GetListExists;
                response.Errors = null;
            }
            return response;
        }
    }
}