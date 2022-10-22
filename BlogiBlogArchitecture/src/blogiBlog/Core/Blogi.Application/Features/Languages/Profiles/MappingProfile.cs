using Blogi.Application.Features.Languages.Dtos.Create;
using Blogi.Application.Features.Languages.Dtos.Get;
using Blogi.Application.Features.Languages.Dtos.GetList;

namespace Blogi.Application.Features.Languages.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Language, GetLanguageOutput>();
            CreateMap<Language, GetListLanguageOutput>();            
            CreateMap<Language, CreateLanguageOutput>().ReverseMap();
        }
    }
}
