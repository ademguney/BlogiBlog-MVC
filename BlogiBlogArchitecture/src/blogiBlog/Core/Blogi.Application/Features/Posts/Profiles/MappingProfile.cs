using Blogi.Application.Features.Posts.Commands;
using Blogi.Application.Features.Posts.Dtos.Get;
using Blogi.Application.Features.Posts.Dtos.GetList;

namespace Blogi.Application.Features.Posts.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, CreatePostCommand>().ReverseMap();
            CreateMap<Post, GetListPostOutput>().ReverseMap();
            CreateMap<Post, GetPostOutput>()
                .ForMember(x => x.Image, d => d.MapFrom(s => Convert.ToBase64String(s.Image)));
        }
    }
}