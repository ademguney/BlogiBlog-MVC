using Blogi.Application.Features.Abouts.Dtos.Get;
using Blogi.Application.Features.Languages.Dtos.GetList;

namespace Blogi.Dashboard.Models
{
    public class AboutEditViewModel
    {
        public List<GetListLanguageOutput> LanguageList { get; set; }
        public GetAboutOutput About { get; set; }
    }
}