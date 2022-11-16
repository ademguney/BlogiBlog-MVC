namespace Blogi.Application.Features.Comment.Dtos.Get
{
    public class GetCommentOutput
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string CategoryName { get; set; }
        public string PostName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsPublish { get; set; }
        public string CreationDate { get; set; }
    }
}