using Blogi.Application.Features.Categories.Commands.Create;
using Blogi.Application.Features.Languages.Dtos.GetList;

namespace Blogi.Dashboard.Models
{
    public class CategoryCreateViewModel
    {
        public List<GetListLanguageOutput> LanguageList { get; set; }
        public CreateCategoryCommand CategoryCommand { get; set; }
    }
}
