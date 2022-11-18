using Blogi.Application.Features.StringResources.Commands.Create;
using Blogi.Application.Features.StringResources.Commands.Delete;
using Blogi.Application.Features.StringResources.Commands.Update;
using Blogi.Application.Features.StringResources.Dtos.Create;
using Blogi.Application.Features.StringResources.Dtos.Delete;
using Blogi.Application.Features.StringResources.Dtos.Get;
using Blogi.Application.Features.StringResources.Dtos.GetList;

namespace Blogi.Application.Features.StringResources.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StringResource, GetStringResourceOutput>();
            CreateMap<StringResource, GetListStringResourceOutput>();

            CreateMap<StringResource, CreateStringResourceOutput>().ReverseMap();
            CreateMap<StringResource, CreateStringResourceCommand>().ReverseMap();

            CreateMap<StringResource, DeleteStringResourceOutput>().ReverseMap();
            CreateMap<StringResource, DeleteStringResourceCommand>().ReverseMap();

           
            CreateMap<StringResource, UpdateStringResourceCommand>().ReverseMap();
        }
    }
}
