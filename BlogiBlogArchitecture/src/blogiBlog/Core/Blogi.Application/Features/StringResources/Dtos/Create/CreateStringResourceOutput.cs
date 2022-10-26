namespace Blogi.Application.Features.StringResources.Dtos.Create
{
    public class CreateStringResourceOutput
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string Language { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
