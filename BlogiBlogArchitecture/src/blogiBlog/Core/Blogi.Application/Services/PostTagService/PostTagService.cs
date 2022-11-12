namespace Blogi.Application.Services.PostTagService
{
    public class PostTagService : IPostTagService
    {
        private readonly IPostTagsWriteRepository _postTagWriteRepository;
        private readonly IPostTagsReadRepository _postTagsReadRepository;


        public PostTagService(IPostTagsWriteRepository postTagWriteRepository, IPostTagsReadRepository postTagsReadRepository)
        {
            _postTagWriteRepository = postTagWriteRepository;
            _postTagsReadRepository = postTagsReadRepository;
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