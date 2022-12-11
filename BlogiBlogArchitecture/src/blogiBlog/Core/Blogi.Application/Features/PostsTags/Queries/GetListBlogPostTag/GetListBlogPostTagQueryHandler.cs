using Blogi.Application.Features.Posts.Dtos.GetListBlogPost;

namespace Blogi.Application.Features.PostsTags.Queries.GetListBlogPostTag
{
    public class GetListBlogPostTagQueryHandler : IRequestHandler<GetListBlogPostTagQuery, BaseCommandResponse<List<GetListBlogPostOutput>>>
    {
        private readonly IPostTagService _postTagService;

        public GetListBlogPostTagQueryHandler(IPostTagService postTagService)
        {
            _postTagService = postTagService;
        }

        public async Task<BaseCommandResponse<List<GetListBlogPostOutput>>> Handle(GetListBlogPostTagQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<List<GetListBlogPostOutput>>();
            var result = await _postTagService.GetListBlogTagAsync(request.TagId);
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