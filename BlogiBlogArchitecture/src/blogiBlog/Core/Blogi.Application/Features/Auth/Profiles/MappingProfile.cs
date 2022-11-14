using Blogi.Application.Features.Auth.Dto.GetLogin;

namespace Blogi.Application.Features.Auth.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User,GetLoginOutput>().ReverseMap();
        }
    }
}