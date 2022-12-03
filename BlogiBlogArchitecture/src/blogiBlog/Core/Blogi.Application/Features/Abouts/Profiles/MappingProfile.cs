using Blogi.Application.Features.Abouts.Commands.Create;
using Blogi.Application.Features.Abouts.Commands.Delete;
using Blogi.Application.Features.Abouts.Commands.Update;
using Blogi.Application.Features.Abouts.Dtos.Get;

namespace Blogi.Application.Features.Abouts.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<About, GetAboutOutput>().ReverseMap();
            CreateMap<About, UpdateAboutCommand>().ReverseMap();
            CreateMap<About, DeleteAboutCommand>().ReverseMap();
            CreateMap<About, CreateAboutCommand>().ReverseMap();
        }
    }
}