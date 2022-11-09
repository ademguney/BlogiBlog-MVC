using Blogi.Application.Features.Categories.Dtos.Get;
using Blogi.Application.Features.Languages.Dtos.GetList;
using Blogi.Application.Features.Posts.Dtos.Get;
using Blogi.Application.Features.Tags.Dtos.Get;

namespace Blogi.Dashboard.Models
{
    public class PostCreateViewModel
    {
        public GetPostOutput Post { get; set; }
        public List<GetListLanguageOutput> LanguageList { get; set; }
        public List<GetCategoryOutput> CategoryList { get; set; }
        public List<GetTagOutput> TagList { get; set; }
        public IFormFile File { get; set; }
        public int[] TagIds { get; set; }
    }
}