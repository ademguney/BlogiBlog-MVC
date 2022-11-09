using Blogi.Application.Features.Posts.Dtos.Get;

namespace Blogi.Application.Features.Posts.Commands
{
    public class CreatePostCommand : IRequest<BaseCommandResponse<GetPostOutput>>
    {
        public int UserId { get; set; }
        public int LanguageId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Slug { get; set; }
        public byte[] Image { get; set; }
        public string ImageAlt { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public bool IsPublished { get; set; }
    }
}
