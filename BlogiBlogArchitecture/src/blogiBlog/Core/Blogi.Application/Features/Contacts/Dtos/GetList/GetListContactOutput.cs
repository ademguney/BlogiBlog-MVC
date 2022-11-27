namespace Blogi.Application.Features.Contacts.Dtos.GetList
{
    public class GetListContactOutput
    {
        public int Id { get; set; }
        public string LanguageName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public string Slug { get; set; }
    }
}