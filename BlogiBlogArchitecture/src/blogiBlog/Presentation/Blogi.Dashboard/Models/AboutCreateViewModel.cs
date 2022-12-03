using Blogi.Application.Features.Abouts.Commands.Create;
using Blogi.Application.Features.Languages.Dtos.GetList;

namespace Blogi.Dashboard.Models
{
    public class AboutCreateViewModel
    {
        public List<GetListLanguageOutput> LanguageList { get; set; }
        public CreateAboutCommand AboutCommand { get; set; }
    }
}