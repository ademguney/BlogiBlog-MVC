using Blogi.Application.Features.Languages.Dtos.GetList;
using Blogi.Application.Features.Tags.Commands.Create;

namespace Blogi.Dashboard.Models
{
    public class TagCreateViewModel
    {
        public List<GetListLanguageOutput> LanguageList { get; set; }
        public CreateTagCommand TagCommand { get; set; }
    }
}
