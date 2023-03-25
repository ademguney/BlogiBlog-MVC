using Blogi.Application.Features.Tags.Commands.Create;
using Blogi.Application.Features.Tags.Commands.Delete;
using Blogi.Application.Features.Tags.Commands.Update;
using Blogi.Application.Features.Tags.Dtos.Get;

namespace Blogi.Application.Features.Tags.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {           
            CreateMap<Tag, CreateTagCommand>().ReverseMap();
            CreateMap<Tag, UpdateTagCommand>().ReverseMap();
            CreateMap<Tag, DeleteTagCommand>().ReverseMap();
            CreateMap<Tag, GetTagOutput>().ReverseMap();
        }
    }
}