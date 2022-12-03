using Blogi.Application.Features.Categories.Dtos.Get;
using Blogi.Application.Features.Categories.Dtos.GetCategoryList;

namespace Blogi.Application.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryReadRepository _categoryReadRepository;

        public CategoryService(ICategoryReadRepository categoryReadRepository)
        {
            _categoryReadRepository = categoryReadRepository;
        }

        public async Task<GetCategoryOutput> GetAsync(int id)
        {
            return await _categoryReadRepository.GetAll(x => x.Id == id).Include(x => x.Languages).Select(x => new GetCategoryOutput
            {
                Id = x.Id,
                LanguageId = x.LanguageId,
                LanguageName = x.Languages.Name,
                Culture = x.Languages.Culture,
                Name = x.Name,
                Description = x.Description,
                Slug = x.Slug
            }).FirstOrDefaultAsync();
        }

        public async Task<List<GetCategoryOutput>> GetListAsync()
        {
            return await _categoryReadRepository.GetAll().Include(x => x.Languages).Select(x => new GetCategoryOutput
            {
                Id = x.Id,
                LanguageId = x.LanguageId,
                LanguageName = x.Languages.Name,
                Culture = x.Languages.Culture,
                Name = x.Name,
                Description = x.Description,
                Slug = x.Slug
            }).ToListAsync();
        }

        public async Task<List<GetCategoryListOutput>> GetListAsync(string culture)
        {
            var query = await _categoryReadRepository
                .GetAll(x => x.Languages.Culture.Trim().ToLower() == culture.Trim().ToLower())
                .Select(x => new GetCategoryListOutput
                {
                    Id = x.Id,
                    Name = x.Name,
                    Slug = x.Slug,
                    Count = x.Posts.Count()

                }).ToListAsync();

            return query;
        }
    }
}