using Blogi.Application.Features.Tags.Dtos.Get;
using Blogi.Application.Features.Tags.Dtos.GetTagList;

namespace Blogi.Application.Services.TagService
{
    public class TagService : ITagService
    {
        private readonly ITagReadRepository _tagReadRepository;

        public TagService(ITagReadRepository tagReadRepository)
        {
            _tagReadRepository = tagReadRepository;
        }

        public async Task<GetTagOutput> GetAsync(int id)
        {
            return await _tagReadRepository.GetAll(x => x.Id == id).Include(x => x.Languages).Select(x => new GetTagOutput
            {
                Id = x.Id,
                LanguageId = x.Languages.Id,
                LanguageName = x.Languages.Name,
                Name = x.Name
            }).FirstOrDefaultAsync();
        }

        public async Task<List<GetTagListOutput>> GetListAsync(string culture)
        {
            var result = new List<GetTagListOutput>();
            if (string.IsNullOrEmpty(culture))
            {
                result = await _tagReadRepository.GetAll()
               .Include(x => x.Languages)
               .Select(x => new GetTagListOutput
               {
                   Id = x.Id,
                   Name = x.Name,
                   LanguageName = x.Languages.Name,
                   Slug = x.Slug
               }).ToListAsync();
                return result;
            }

            result = await _tagReadRepository
                .GetAll(x => x.Languages.Culture.Trim().ToLower() == culture.Trim().ToLower())
                .Include(x => x.Languages)
                .Select(x => new GetTagListOutput
                {
                    Id = x.Id,
                    Name = x.Name,
                    LanguageName = x.Languages.Name,
                    Slug = x.Slug
                }).ToListAsync();

            return result;
        }
    }
}