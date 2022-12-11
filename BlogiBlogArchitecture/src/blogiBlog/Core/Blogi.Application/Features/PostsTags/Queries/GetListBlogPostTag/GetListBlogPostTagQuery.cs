using Blogi.Application.Features.Posts.Dtos.GetListBlogPost;

namespace Blogi.Application.Features.PostsTags.Queries.GetListBlogPostTag
{
    public class GetListBlogPostTagQuery : IRequest<BaseCommandResponse<List<GetListBlogPostOutput>>>
    {
        public int TagId { get; set; }
    }
}