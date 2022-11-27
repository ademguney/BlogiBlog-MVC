using Blogi.Application.Features.WebSettings.Commands.Update;
using Blogi.Application.Features.WebSettings.Dtos.Get;

namespace Blogi.Application.Features.WebSettings.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WebSetting, GetWebSettingOutput>().ReverseMap();
            CreateMap<WebSetting, UpdateWebSettingCommand>().ReverseMap();
        }
    }
}