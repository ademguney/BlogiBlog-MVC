using Blogi.Application.Features.Posts.Dtos.GetBlogPost;

namespace Blogi.Application.Features.Posts.Queries.GetBlogPost
{
    public class GetBlogPostQuery : IRequest<BaseCommandResponse<GetBlogPostOutput>>
    {
        public int Id { get; set; }
    }
}