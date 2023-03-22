using Blogi.Application.Features.Tags.Commands.Create;
using Blogi.Application.Features.Tags.Commands.Delete;
using Blogi.Application.Features.Tags.Commands.Update;

namespace Blogi.Application.Features.Tags.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {           
            CreateMap<Tag, CreateTagCommand>().ReverseMap();
            CreateMap<Tag, UpdateTagCommand>().ReverseMap();
            CreateMap<Tag, DeleteTagCommand>().ReverseMap();
        }
    }
}