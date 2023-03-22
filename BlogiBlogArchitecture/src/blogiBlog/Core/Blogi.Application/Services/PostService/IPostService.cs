using Blogi.Application.Features.Posts.Dtos.GetBlogPost;
using Blogi.Application.Features.Posts.Dtos.GetList;
using Blogi.Application.Features.Posts.Dtos.GetListBlogPost;
using Blogi.Application.Features.Posts.Dtos.GetMostReadPost;

namespace Blogi.Application.Services.PostService
{
    public interface IPostService
    {
        Task<List<GetMostReadPostOutput>> GetMostReadAsync();
        Task<GetBlogPostOutput> GetBlogPost(int id);
        Task<List<GetListPostOutput>> GetListAsync(int languageId);
        Task<List<GetListBlogPostOutput>> GetListBlogPostAsync(string culture, string searchText);
    }
}