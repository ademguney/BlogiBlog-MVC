namespace Blogi.Application.Features.Abouts.Dtos.Get
{
    public class GetAboutOutput
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string Title { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public string Content { get; set; }
        public string Slug { get; set; }
    }
}