using Blogi.Application.Features.Categories.Dtos.Get;

namespace Blogi.Application.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<GetCategoryOutput> GetAsync(int id);
        Task<List<GetCategoryOutput>> GetListAsync();
    }
}
