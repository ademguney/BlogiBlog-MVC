using Blogi.Application.Features.StringResources.Dtos.GitList;

namespace Blogi.Application.Features.StringResources.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StringResource, GetListStringResourceOutput>();
        }
    }
}
