using Blogi.Application.Features.Categories.Dtos.Get;
using Blogi.Application.Features.Categories.Dtos.GetCategoryList;

namespace Blogi.Application.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<GetCategoryOutput> GetAsync(int id);
        Task<List<GetCategoryOutput>> GetListAsync();
        Task<List<GetCategoryListOutput>> GetListAsync(string culture);
    }
}