using Blogi.Application.Features.Comments.Dtos.GetBlogComment;

namespace Blogi.Application.Features.Posts.Dtos.GetBlogPost
{
    public class GetBlogPostOutput
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategorySlug { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public string Slug { get; set; }
        public string AuthorPhoto { get; set; }
        public string Image { get; set; }
        public string ImageAlt { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }       
        public string CreationDate { get; set; }
        public Dictionary<int,string> Tags { get; set; }
        public List<GetBlogCommentOutput> Comments { get; set; }
    }
}