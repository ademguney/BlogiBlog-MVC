using Blogi.Application.Features.Posts.Dtos.GetBlogPost;
using Blogi.Application.Features.Posts.Dtos.GetList;
using Blogi.Application.Features.Posts.Dtos.GetListBlogPost;

namespace Blogi.Application.Services.PostService
{
    public interface IPostService
    {
        Task<GetBlogPostOutput> GetBlogPost(int id);
        Task<List<GetListPostOutput>> GetListAsync();
        Task<List<GetListBlogPostOutput>> GetListBlogPostAsync(string culture);
    }
}