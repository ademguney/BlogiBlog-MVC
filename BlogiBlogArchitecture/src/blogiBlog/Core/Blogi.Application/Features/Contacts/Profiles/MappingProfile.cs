using Blogi.Application.Features.Contacts.Commands.Create;
using Blogi.Application.Features.Contacts.Commands.Delete;
using Blogi.Application.Features.Contacts.Commands.Update;
using Blogi.Application.Features.Contacts.Dtos.Get;

namespace Blogi.Application.Features.Contacts.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.Contact, GetContactOutput>().ReverseMap();
            CreateMap<Domain.Entities.Contact, UpdateContactCommand>().ReverseMap();
            CreateMap<Domain.Entities.Contact, DeleteContactCommand>().ReverseMap();
            CreateMap<Domain.Entities.Contact, CreateContactCommand>().ReverseMap();
        }
    }
}