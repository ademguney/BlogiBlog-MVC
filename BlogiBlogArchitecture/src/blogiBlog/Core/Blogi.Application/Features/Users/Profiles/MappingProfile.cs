using Blogi.Application.Features.Users.Commands.Update;
using Blogi.Application.Features.Users.Dtos.Get;

namespace Blogi.Application.Features.Users.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, GetUserOutput>()
                .ForMember(x => x.Photo, d => d.MapFrom(s => Convert.ToBase64String(s.Photo)));

            CreateMap<User, UpdateUserCommand>().ReverseMap();                
        }
    }
}