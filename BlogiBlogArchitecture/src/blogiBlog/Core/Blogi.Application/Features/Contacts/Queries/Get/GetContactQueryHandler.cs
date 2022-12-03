using Blogi.Application.Features.Contacts.Dtos.Get;
using Blogi.Application.Features.Contacts.Queries.Get;

namespace Blogi.Application.Features.Contact.Queries.Get
{
    public class GetContactQueryHandler : IRequestHandler<GetContactQuery, BaseCommandResponse<GetContactOutput>>
    {
        private readonly IMapper _mapper;
        private readonly IContactService _contactService;

        public GetContactQueryHandler(IMapper mapper, IContactService contactService)
        {
            _mapper = mapper;
            _contactService = contactService;
        }

        public async Task<BaseCommandResponse<GetContactOutput>> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<GetContactOutput>();
            var result = await _contactService.GetAsync(request.Id, request.Culture);

            var resultMapp = _mapper.Map<GetContactOutput>(result);
            response.Id = resultMapp.Id;
            response.Data = resultMapp;
            response.Success = true;
            response.Message = ContactMessages.GetByIdExists;
            response.Errors = null;

            return response;
        }
    }
}