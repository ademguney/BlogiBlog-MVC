using Blogi.Application.Features.Contract.Dtos.Get;

namespace Blogi.Application.Features.Contact.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.Contact,GetContactOutput>().ReverseMap();
        }
    }
}