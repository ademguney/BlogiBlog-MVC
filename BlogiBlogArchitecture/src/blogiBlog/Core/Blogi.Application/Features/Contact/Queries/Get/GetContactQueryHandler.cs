using Blogi.Application.Features.Contract.Dtos.Get;

namespace Blogi.Application.Features.Contact.Queries.Get
{
    public class GetContactQueryHandler : IRequestHandler<GetContactQuery, BaseCommandResponse<GetContactOutput>>
    {
        private readonly IMapper _mapper;
        private readonly IContactReadRepository _contactReadRepository;

        public GetContactQueryHandler(IMapper mapper, IContactReadRepository contactReadRepository)
        {
            _mapper = mapper;
            _contactReadRepository = contactReadRepository;
        }

        public async Task<BaseCommandResponse<GetContactOutput>> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<GetContactOutput>();
            var result = await _contactReadRepository.GetAll().FirstOrDefaultAsync();

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