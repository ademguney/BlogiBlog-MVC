using Blogi.Application.Features.MailSettings.Commands.Update;
using Blogi.Application.Features.MailSettings.Dtos.Get;

namespace Blogi.Application.Features.MailSettings.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MailSetting, GetMailSettingOutput>().ReverseMap();
            CreateMap<MailSetting, UpdateMailSettingCommand>().ReverseMap();
        }
    }
}
