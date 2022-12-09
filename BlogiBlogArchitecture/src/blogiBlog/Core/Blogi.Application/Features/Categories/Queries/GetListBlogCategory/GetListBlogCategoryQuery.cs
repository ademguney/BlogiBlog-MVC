using Blogi.Application.Features.Posts.Dtos.GetListBlogPost;

namespace Blogi.Application.Features.Categories.Queries.GetListBlogCategory
{
    public class GetListBlogCategoryQuery : IRequest<BaseCommandResponse<List<GetListBlogPostOutput>>>
    {
        public int Id { get; set; }
    }
}