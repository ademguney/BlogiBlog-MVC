namespace Blogi.Application.Features.Categories.Dtos.Get
{
    public class GetCategoryOutput
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
    }
}
