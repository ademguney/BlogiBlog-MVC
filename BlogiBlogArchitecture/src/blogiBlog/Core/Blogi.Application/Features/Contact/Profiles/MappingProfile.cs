using Blogi.Application.Features.Contact.Commands.Create;
using Blogi.Application.Features.Contact.Commands.Delete;
using Blogi.Application.Features.Contact.Commands.Update;
using Blogi.Application.Features.Contract.Dtos.Get;

namespace Blogi.Application.Features.Contact.Profiles
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