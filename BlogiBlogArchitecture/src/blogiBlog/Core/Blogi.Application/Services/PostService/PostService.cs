using Blogi.Application.Features.Comments.Dtos.GetBlogComment;
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
               .Include(x => x.Comments)
               .OrderByDescending(x => x.CreationDate)
               .Select(x => new GetBlogPostOutput
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
                   Image = x.Image != null ? Convert.ToBase64String(x.Image) : null,
                   ImageAlt = x.ImageAlt,
                   Content = x.Content,
                   MetaDescription = x.MetaDescription,
                   MetaKeywords = x.MetaKeywords,
                   Tags = tagList,
                   Comments = x.Comments.Where(c => c.IsPublish == true).Select(c => new GetBlogCommentOutput
                   {
                       Id = c.Id,
                       ParentId = c.ParentId,
                       FullName = c.FullName,
                       Content = c.Content,
                       CreationDate = c.CreationDate.ToLongDateString()

                   }).ToList()
               })
               .FirstOrDefaultAsync();
            return query;
        }

        public async Task<List<GetListPostOutput>> GetListAsync()
        {
            var query = _postReadRepository.GetAll()
                                           .Include(x => x.Categories)
                                           .Include(x => x.Languages);
            return await query.Select(x => new GetListPostOutput
            {
                Id = x.Id,
                LanguageName = x.Languages.Name,
                CategoryName = x.Categories.Name,
                Title = x.Title,
                IsPublished = x.IsPublished,
                CreationDate = x.CreationDate.ToShortDateString(),
                UpdationDate = x.UpdationDate.HasValue ? x.UpdationDate.Value.ToShortDateString() : null
            }).ToListAsync();
        }

        public async Task<List<GetListBlogPostOutput>> GetListBlogPostAsync(string culture, string searchText)
        {
            var query = _postReadRepository
                .GetAll(x => x.Languages.Culture.Trim().ToLower() == culture.Trim().ToLower() && x.IsPublished)
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
                    Image = x.Image != null ? Convert.ToBase64String(x.Image) : null,
                    ImageAlt = x.ImageAlt
                });

            if (!string.IsNullOrEmpty(searchText))
                query = query.Where(x => x.Title.Contains(searchText) || x.CategoryName.Contains(searchText));

            return await query.ToListAsync();
        }
    }
}