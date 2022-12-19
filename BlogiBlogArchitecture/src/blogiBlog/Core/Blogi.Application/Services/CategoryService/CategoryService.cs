using Blogi.Application.Features.Categories.Dtos.Get;
using Blogi.Application.Features.Categories.Dtos.GetCategoryList;
using Blogi.Application.Features.Posts.Dtos.GetListBlogPost;

namespace Blogi.Application.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IPostReadRepository _postReadRepository;

        public CategoryService(ICategoryReadRepository categoryReadRepository, IPostReadRepository postReadRepository)
        {
            _categoryReadRepository = categoryReadRepository;
            _postReadRepository = postReadRepository;
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

        public async Task<List<GetListBlogPostOutput>> GetListBlogCategoryAsync(int id)
        {
            var query = _postReadRepository
                .GetAll(x => x.CategoryId == id)
                .Include(x => x.Categories)
                .Include(x => x.Languages);
            return await query.Select(x => new GetListBlogPostOutput
            {
                Id = x.Id,
                CategoryId = x.CategoryId,
                CategoryName = x.Categories.Name,
                CategorySlug=x.Categories.Slug,
                Title = x.Title,
                Author = x.Users.Name + " " + x.Users.Surname,
                AuthorPhoto = x.Users.Photo != null ? Convert.ToBase64String(x.Users.Photo) : null,
                Slug = x.Slug,
                CreationDate = x.CreationDate.ToLongDateString(),               
                Image = x.Image != null ? Convert.ToBase64String(x.Image) : null,
                ImageAlt = x.ImageAlt
            }).ToListAsync();
        }
    }
}