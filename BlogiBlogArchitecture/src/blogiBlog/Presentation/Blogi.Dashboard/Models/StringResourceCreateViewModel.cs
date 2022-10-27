using Blogi.Application.Features.Languages.Dtos.GetList;
using Blogi.Application.Features.StringResources.Commands.Create;

namespace Blogi.Dashboard.Models
{
    public class StringResourceCreateViewModel
    {
        public List<GetListLanguageOutput> LanguageList { get; set; }
        public CreateStringResourceCommand StringResourceCommand { get; set; }
    }
}
