namespace Blogi.Application.Features.StringResources.Dtos.Update
{
    public class UpdateStringResourceOutput
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
