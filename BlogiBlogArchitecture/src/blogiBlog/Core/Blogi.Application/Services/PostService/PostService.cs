using Blogi.Application.Features.Posts.Dtos.GetList;

namespace Blogi.Application.Services.PostService
{
    public class PostService : IPostService
    {
        private readonly IPostReadRepository _postReadRepository;

        public PostService(IPostReadRepository postReadRepository)
        {
            _postReadRepository = postReadRepository;
        }

        public async Task<List<GetListPostOutput>> GetListAsync()
        {
            var query = _postReadRepository.GetAll().Include(x => x.Categories).Include(x => x.Languages);
            return await query.Select(x => new GetListPostOutput
            {
                Id = x.Id,
                LanguageName = x.Languages.Name,
                CategoryName = x.Categories.Name,
                Title = x.Title,
                DisplayCount = x.DisplayCount,
                IsPublished = x.IsPublished,
                CreationDate = x.CreationDate.ToShortDateString(),
                UpdationDate = x.UpdationDate.HasValue ? x.UpdationDate.Value.ToShortDateString() : null
            }).ToListAsync();
        }
    }
}