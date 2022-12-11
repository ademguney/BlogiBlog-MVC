using Blogi.Application.Features.Posts.Dtos.GetBlogPost;
using Blogi.Application.Features.Posts.Dtos.GetList;
using Blogi.Application.Features.Posts.Dtos.GetListBlogPost;

namespace Blogi.Application.Services.PostService
{
    public class PostService : IPostService
    {
        private readonly IPostReadRepository _postReadRepository;
        private readonly IPostTagsReadRepository _postTagsReadRepository;

        public PostService(IPostReadRepository postReadRepository, IPostTagsReadRepository postTagsReadRepository)
        {
            _postReadRepository = postReadRepository;
            _postTagsReadRepository = postTagsReadRepository;
        }

        public async Task<GetBlogPostOutput> GetBlogPost(int id)
        {

            var tags = await _postTagsReadRepository.GetAll(x => x.PostId == id).Include(x => x.Tags).ToListAsync();
            var tagList = new Dictionary<int, string>();
            if (tags is not null)
            {
                foreach (var item in tags)
                {
                    tagList.Add(item.TagId, item.Tags.Slug);
                }
            }

            var query = await _postReadRepository
               .GetAll(x => x.Id == id)
               .Include(x => x.Languages)
               .Include(x => x.Users)
               .Include(x => x.Categories)
               .OrderByDescending(x => x.CreationDate)
               .Select(x => new GetBlogPostOutput
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
                   DisplayCount = x.DisplayCount,
                   Image = x.Image != null ? Convert.ToBase64String(x.Image) : null,
                   ImageAlt = x.ImageAlt,
                   Content = x.Content,
                   MetaDescription = x.MetaDescription,
                   MetaKeywords = x.MetaKeywords,
                   Tags = tagList
               })
               .FirstOrDefaultAsync();
            return query;
        }

        public async Task<List<GetListPostOutput>> GetListAsync()
        {
            var query = _postReadRepository.GetAll(x => x.IsPublished)
                                           .Include(x => x.Categories)
                                           .Include(x => x.Languages);
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

        public async Task<List<GetListBlogPostOutput>> GetListBlogPostAsync(string culture)
        {
            var query = await _postReadRepository
                .GetAll(x => x.Languages.Culture.Trim().ToLower() == culture.Trim().ToLower())
                .Include(x => x.Languages)
                .Include(x => x.Users)
                .Include(x => x.Categories)
                .OrderByDescending(x => x.CreationDate)
                .Select(x => new GetListBlogPostOutput
                {
                    Id = x.Id,
                    CategoryId = x.CategoryId,
                    CategoryName = x.Categories.Name,
                    CategorySlug = x.Categories.Slug,
                    Title = x.Title,
                    Author = x.Users.Name + " " + x.Users.Surname,
                    AuthorPhoto = x.Users.Photo != null ? Convert.ToBase64String(x.Users.Photo) : null,
                    Slug = x.Slug,
                    CreationDate = x.CreationDate.ToLongDateString(),
                    DisplayCount = x.DisplayCount,
                    Image = x.Image != null ? Convert.ToBase64String(x.Image) : null,
                    ImageAlt = x.ImageAlt
                })
                .ToListAsync();
            return query;
        }
    }
}