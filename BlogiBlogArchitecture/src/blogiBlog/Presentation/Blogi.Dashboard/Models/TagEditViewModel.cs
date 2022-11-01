using Blogi.Application.Features.Languages.Dtos.GetList;
using Blogi.Application.Features.Tags.Dtos.Get;

namespace Blogi.Dashboard.Models
{
    public class TagEditViewModel
    {
        public List<GetListLanguageOutput> LanguageList { get; set; }
        public GetTagOutput Tag { get; set; }
    }
}
