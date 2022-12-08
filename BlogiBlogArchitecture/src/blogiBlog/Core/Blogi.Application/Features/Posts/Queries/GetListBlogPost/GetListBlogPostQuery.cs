using Blogi.Application.Features.Posts.Dtos.GetListBlogPost;

namespace Blogi.Application.Features.Posts.Queries.GetListBlogPost
{
    public class GetListBlogPostQuery : IRequest<BaseCommandResponse<List<GetListBlogPostOutput>>>
    {
        public string Culture { get; set; }
    }
}