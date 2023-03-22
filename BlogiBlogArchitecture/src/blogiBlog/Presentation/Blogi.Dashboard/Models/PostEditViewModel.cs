using Blogi.Application.Features.Categories.Dtos.Get;
using Blogi.Application.Features.Posts.Dtos.Get;
using Blogi.Application.Features.Tags.Dtos.GetTagList;

namespace Blogi.Dashboard.Models
{
    public class PostEditViewModel
    {
        public GetPostOutput Post { get; set; }        
        public List<GetCategoryOutput> CategoryList { get; set; }
        public List<GetTagListOutput> TagList { get; set; }
        public IFormFile File { get; set; }
        public List<int> TagIds { get; set; }
    }
}