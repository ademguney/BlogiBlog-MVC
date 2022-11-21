using Core.Persistence.Common;

namespace Blogi.Domain.Entities
{
    public class About : BaseDomainEntity
    {
        public About() { }

        public About(int id, int languageId, string title, string metaDescription, string metaKeywords, string content, string slug) : base(id)
        {
            LanguageId = languageId;
            Title = title;
            MetaDescription = metaDescription;
            MetaKeywords = metaKeywords;
            Content = content;
            Slug = slug;
        }

        public int LanguageId { get; set; }
        public string Title { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public string Content { get; set; }
        public string Slug { get; set; }

        public Language Languages { get; set; }
    }
}