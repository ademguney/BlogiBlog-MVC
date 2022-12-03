using Blogi.Application.Features.Contacts.Dtos.Get;

namespace Blogi.Application.Features.Contacts.Commands.Create
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, BaseCommandResponse<GetContactOutput>>
    {
        private readonly IMapper _mapper;
        private readonly IContactReadRepository _contactReadRepository;
        private readonly IContactWriteRepository _contactWriteRepository;

        public CreateContactCommandHandler(IMapper mapper, IContactReadRepository contactReadRepository, IContactWriteRepository contactWriteRepository)
        {
            _mapper = mapper;
            _contactReadRepository = contactReadRepository;
            _contactWriteRepository = contactWriteRepository;
        }

        public async Task<BaseCommandResponse<GetContactOutput>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<GetContactOutput>();
            var validator = new CreateContactCommandHandlerValidatior(_contactReadRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                response.Data = null;
                response.Success = false;
                response.Message = null;
                response.Errors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var contactMapp = _mapper.Map<Domain.Entities.Contact>(request);
                var result = await _contactWriteRepository.AddAsync(contactMapp);
                var resultMapp = _mapper.Map<GetContactOutput>(result);

                response.Id = resultMapp.Id;
                response.Data = resultMapp;
                response.Success = true;
                response.Message = ContactMessages.CreatedSuccess;
                response.Errors = null;
            }

            return response;
        }
    }
}