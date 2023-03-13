using Core.Persistence.Common;

namespace Blogi.Domain.Entities
{
    public class Contact : BaseDomainEntity
    {
        public Contact() { }

        public Contact(int id, int languageId, int countOfView, string location, string phone, string email, string slug, string title, string metaDescription, string metaKeywords, string content) : base(id)
        {
            LanguageId = languageId;
            CountOfView = countOfView;
            Location = location;
            Phone = phone;
            Email = email;
            Slug = slug;
            Title = title;
            MetaDescription = metaDescription;
            MetaKeywords = metaKeywords;
            Content = content;
        }

        public int LanguageId { get; set; }
        public int CountOfView { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public string Content { get; set; }


        public Language Languages { get; set; }
    }
}