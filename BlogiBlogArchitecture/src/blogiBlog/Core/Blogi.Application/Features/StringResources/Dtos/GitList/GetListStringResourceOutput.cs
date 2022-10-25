namespace Blogi.Application.Features.StringResources.Dtos.GitList
{
    public class GetListStringResourceOutput 
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string Language { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
