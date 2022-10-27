using Blogi.Application.Features.Languages.Dtos.GetList;
using Blogi.Application.Features.StringResources.Dtos.Get;

namespace Blogi.Dashboard.Models
{
    public class StringResourceEditViewModel
    {
        public List<GetListLanguageOutput> LanguageList { get; set; }
        public GetStringResourceOutput StringResource { get; set; }
    }
}
