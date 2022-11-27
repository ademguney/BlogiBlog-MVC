using Blogi.Application.Features.Contacts.Constants;

namespace Blogi.Application.Features.Contacts.Commands.Delete
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, BaseCommandResponse<int>>
    {
        private readonly IMapper _mapper;
        private readonly IContactReadRepository _contactReadRepository;
        private readonly IContactWriteRepository _contactWriteRepository;

        public DeleteContactCommandHandler(IMapper mapper, IContactReadRepository contactReadRepository, IContactWriteRepository contactWriteRepository)
        {
            _mapper = mapper;
            _contactReadRepository = contactReadRepository;
            _contactWriteRepository = contactWriteRepository;
        }

        public async Task<BaseCommandResponse<int>> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();
            var validator = new DeleteContactCommandHandlerValidatior(_contactReadRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                response.Data = 0;
                response.Success = false;
                response.Message = null;
                response.Errors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var contactMapp = _mapper.Map<Domain.Entities.Contact>(request);
                var result = await _contactWriteRepository.DeleteAsync(contactMapp);

                response.Id = result.Id;
                response.Data = result.Id;
                response.Success = true;
                response.Message = ContactMessages.DeletedSuccess;
                response.Errors = null;
            }
            return response;
        }
    }
}