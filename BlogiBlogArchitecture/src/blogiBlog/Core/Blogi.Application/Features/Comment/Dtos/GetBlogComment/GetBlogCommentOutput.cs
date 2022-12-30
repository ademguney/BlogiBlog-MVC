namespace Blogi.Application.Features.Comment.Dtos.GetBlogComment
{
    public class GetBlogCommentOutput
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }        
        public string FullName { get; set; }
        public string Content { get; set; }
        public string CreationDate { get; set; }
    }
}