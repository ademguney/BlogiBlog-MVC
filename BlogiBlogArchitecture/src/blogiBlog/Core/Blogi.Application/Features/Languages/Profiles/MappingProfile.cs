using Blogi.Application.Features.Languages.Commands.Create;
using Blogi.Application.Features.Languages.Commands.Delete;
using Blogi.Application.Features.Languages.Commands.Update;
using Blogi.Application.Features.Languages.Dtos.Create;
using Blogi.Application.Features.Languages.Dtos.Get;
using Blogi.Application.Features.Languages.Dtos.GetList;
using Blogi.Application.Features.Languages.Dtos.Update;

namespace Blogi.Application.Features.Languages.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Language, GetLanguageOutput>();
            CreateMap<Language, GetListLanguageOutput>();

            CreateMap<Language, CreateLanguageCommand>().ReverseMap();
            CreateMap<Language, CreateLanguageOutput>().ReverseMap();

            CreateMap<Language, UpdateLanguageCommand>().ReverseMap();
            CreateMap<Language, UpdateLanguageOutput>().ReverseMap();

            CreateMap<Language, DeleteLanguageCommand>().ReverseMap();
        }
    }
}