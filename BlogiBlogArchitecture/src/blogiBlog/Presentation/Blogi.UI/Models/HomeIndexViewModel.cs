using Blogi.Application.Features.Posts.Dtos.GetListBlogPost;
using Blogi.Application.Features.WebSettings.Dtos.Get;
using X.PagedList;

namespace Blogi.UI.Models
{
    public class HomeIndexViewModel
    {
        public GetWebSettingOutput WebSettings { get; set; }
        public IPagedList<GetListBlogPostOutput> BlogPost { get; set; }
    }
}