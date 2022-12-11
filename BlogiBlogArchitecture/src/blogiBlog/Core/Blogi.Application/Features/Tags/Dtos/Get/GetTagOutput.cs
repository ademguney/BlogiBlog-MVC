namespace Blogi.Application.Features.Tags.Dtos.Get
{
    public class GetTagOutput
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}
