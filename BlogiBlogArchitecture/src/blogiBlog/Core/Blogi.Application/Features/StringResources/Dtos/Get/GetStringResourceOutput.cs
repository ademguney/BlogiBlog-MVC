namespace Blogi.Application.Features.StringResources.Dtos.Get
{
    public class GetStringResourceOutput
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string Language { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}