using Blogi.Application.Features.Post.Dtos.GetList;

namespace Blogi.Application.Features.Post.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.Post, GetListPostOutput>().ReverseMap();
        }
    }
}
