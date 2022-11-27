using Blogi.Application.Features.Contact.Dtos.GetList;

namespace Blogi.Application.Features.Contact.Queries.GetList
{
    public class GetListContactQueryHandler : IRequestHandler<GetListContactQuery, BaseCommandResponse<List<GetListContactOutput>>>
    {
        private readonly IContactService _contactService;

        public GetListContactQueryHandler(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<BaseCommandResponse<List<GetListContactOutput>>> Handle(GetListContactQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<List<GetListContactOutput>>();
            var result = await _contactService.GetListAsync();

            if (!result.Any())
            {
                response.Success = false;
                response.Message = ContactMessages.GetListNotExists;
                response.Errors = null;
                response.Data = new List<GetListContactOutput>();
            }
            else
            {
               
                response.Data = result;
                response.Success = true;
                response.Message = ContactMessages.GetListExists;
                response.Errors = null;
            }
            return response;
        }
    }
}