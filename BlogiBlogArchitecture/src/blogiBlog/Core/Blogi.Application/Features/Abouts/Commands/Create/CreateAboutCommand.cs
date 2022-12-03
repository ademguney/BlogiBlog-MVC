using Blogi.Application.Features.Abouts.Dtos.Get;

namespace Blogi.Application.Features.Abouts.Commands.Create
{
    public class CreateAboutCommand : IRequest<BaseCommandResponse<GetAboutOutput>>
    {
        public int LanguageId { get; set; }
        public string Title { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public string Content { get; set; }
        public string Slug { get; set; }
    }
}