using Blogi.Application.Features.Posts.Dtos.GetListBlogPost;

namespace Blogi.Application.Services.PostTagService
{
    public interface IPostTagService
    {
        Task<int[]> AddAsync(int postId, int[] tagIds);
        Task<bool> DeleteAsync(int postId);
        Task<List<int>> UpdateAsync(int postId, List<int> tagIds);
        Task<List<GetListBlogPostOutput>> GetListBlogTagAsync(int tagId);
    }
}