namespace Blogi.Application.Features.Post.Dtos.GetList
{
    public class GetListPostOutput
    {
        public int Id { get; set; }
        public string LanguageName { get; set; }
        public string CategoryName { get; set; }
        public string Title { get; set; }
        public string CreationDate { get; set; }
        public string UpdationDate { get; set; }
        public int DisplayCount { get; set; }
        public bool IsPublished { get; set; }
    }
}