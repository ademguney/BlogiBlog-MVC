using Blogi.Application.Features.WebSettings.Dtos.Get;

namespace Blogi.Application.Features.WebSettings.Commands.Update
{
    public class UpdateWebSettingCommand : IRequest<BaseCommandResponse<GetWebSettingOutput>>
    {
        public int Id { get; set; }
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
