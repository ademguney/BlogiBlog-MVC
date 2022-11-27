using Blogi.Application.Features.Categories.Dtos.Get;
using Blogi.Application.Features.Languages.Dtos.GetList;

namespace Blogi.Dashboard.Models
{
    public class CategoryEditViewModel
    {
        public List<GetListLanguageOutput> LanguageList { get; set; }
        public GetCategoryOutput Category { get; set; }
    }
}