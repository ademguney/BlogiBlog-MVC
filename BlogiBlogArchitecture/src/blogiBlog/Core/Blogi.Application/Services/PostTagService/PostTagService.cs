using Blogi.Application.Features.Posts.Dtos.GetListBlogPost;

namespace Blogi.Application.Services.PostTagService
{
    public class PostTagService : IPostTagService
    {
        private readonly IPostTagsWriteRepository _postTagWriteRepository;
        private readonly IPostTagsReadRepository _postTagsReadRepository;
        private readonly IPostReadRepository _postReadRepository;
        public PostTagService(
            IPostTagsWriteRepository postTagWriteRepository,
            IPostTagsReadRepository postTagsReadRepository,
            IPostReadRepository postReadRepository
            )
        {
            _postTagWriteRepository = postTagWriteRepository;
            _postTagsReadRepository = postTagsReadRepository;
            _postReadRepository = postReadRepository;
        }

        public async Task<int[]> AddAsync(int postId, int[] tagIds)
        {
            var tagArray = Array.Empty<int>();
            foreach (var item in tagIds)
            {
                var postTags = new PostTags
                {
                    PostId = postId,
                    TagId = item
                };
                var result = await _postTagWriteRepository.AddAsync(postTags);
                _ = tagArray.Append(result.Id);
            }
            return tagArray;
        }

        public async Task<bool> DeleteAsync(int postId)
        {
            var postTag = await _postTagsReadRepository.GetListAsync(x => x.PostId == postId);
            if (postTag is null)
                return false;

            foreach (var item in postTag)
                await _postTagWriteRepository.DeleteAsync(item);
            return true;
        }

        public async Task<List<GetListBlogPostOutput>> GetListBlogTagAsync(int tagId)
        {
            var result = new List<GetListBlogPostOutput>();
            var postTagIds = await _postTagsReadRepository.GetAll(x => x.TagId == tagId).ToListAsync();
            foreach (var item in postTagIds)
            {
                var post = await _postReadRepository
                 .GetAll(x => x.Id == item.PostId)
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
                 }).FirstOrDefaultAsync();
                result.Add(post);
            }
            return result;
        }

        // TODO: need to refactoring...
        public async Task<List<int>> UpdateAsync(int postId, List<int> tagIds)
        {
            var tagArray = new List<int>();
            var postTag = await _postTagsReadRepository.GetListAsync(x => x.PostId == postId);
            if (postTag is null)
                return tagArray;

            foreach (var item in postTag)
                await _postTagWriteRepository.DeleteAsync(item);

            foreach (var item in tagIds)
            {
                var result = await _postTagWriteRepository.AddAsync(new PostTags { PostId = postId, TagId = item });
                _ = tagArray.Append(result.Id);
            }

            return tagArray;
        }
    }
}