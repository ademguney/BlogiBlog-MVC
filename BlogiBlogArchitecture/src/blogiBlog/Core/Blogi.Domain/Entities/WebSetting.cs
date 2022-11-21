using Core.Persistence.Common;

namespace Blogi.Domain.Entities
{
    public class WebSetting : BaseDomainEntity
    {
        public WebSetting() { }

        public WebSetting(int id, string facebookUrl, string twitterUrl, string instagramUrl, string youTubeUrl, string mediumUrl, string githubUrl, string linkedinUrl, bool isDisplayFacebbokUrl, bool isDisplayTwitterUrl, bool isDisplayInstagramUrl, bool isDisplayYouTubeUrl, bool isDisplayMediumUrl, bool isDisplayGithubUrl, bool isDisplayLinkedinUrl, string webSiteUrl, string slogan, string title, string author, string metaDescription, string metaKeywords) : base(id)
        {
            FacebookUrl = facebookUrl;
            TwitterUrl = twitterUrl;
            InstagramUrl = instagramUrl;
            YouTubeUrl = youTubeUrl;
            MediumUrl = mediumUrl;
            GithubUrl = githubUrl;
            LinkedinUrl = linkedinUrl;
            IsDisplayFacebbokUrl = isDisplayFacebbokUrl;
            IsDisplayTwitterUrl = isDisplayTwitterUrl;
            IsDisplayInstagramUrl = isDisplayInstagramUrl;
            IsDisplayYouTubeUrl = isDisplayYouTubeUrl;
            IsDisplayMediumUrl = isDisplayMediumUrl;
            IsDisplayGithubUrl = isDisplayGithubUrl;
            IsDisplayLinkedinUrl = isDisplayLinkedinUrl;
            WebSiteUrl = webSiteUrl;
            Slogan = slogan;
            Title = title;
            Author = author;
            MetaDescription = metaDescription;
            MetaKeywords = metaKeywords;
        }

        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string YouTubeUrl { get; set; }
        public string MediumUrl { get; set; }
        public string GithubUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public bool IsDisplayFacebbokUrl { get; set; }
        public bool IsDisplayTwitterUrl { get; set; }
        public bool IsDisplayInstagramUrl { get; set; }
        public bool IsDisplayYouTubeUrl { get; set; }
        public bool IsDisplayMediumUrl { get; set; }
        public bool IsDisplayGithubUrl { get; set; }
        public bool IsDisplayLinkedinUrl { get; set; }


        public string WebSiteUrl { get; set; }
        public string Slogan { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }

    }
}