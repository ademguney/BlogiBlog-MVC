using Blogi.Application.Features.Categories.Dtos.Get;
using Blogi.Application.Features.Categories.Dtos.GetCategoryList;
using Blogi.Application.Features.Posts.Dtos.GetListBlogPost;

namespace Blogi.Application.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<GetCategoryOutput> GetAsync(int id);
        Task<List<GetCategoryOutput>> GetListAsync();
        Task<List<GetListBlogPostOutput>> GetListBlogCategoryAsync(int id);
        Task<List<GetCategoryListOutput>> GetListAsync(string culture);
    }
}