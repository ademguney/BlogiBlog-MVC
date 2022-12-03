using Blogi.Application.Features.Contacts.Dtos.Get;

namespace Blogi.Application.Features.Contacts.Commands.Update
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, BaseCommandResponse<GetContactOutput>>
    {
        private readonly IMapper _mapper;
        private readonly IContactWriteRepository _contactWriteRepository;

        public UpdateContactCommandHandler(IMapper mapper, IContactWriteRepository contactWriteRepository)
        {
            _mapper = mapper;
            _contactWriteRepository = contactWriteRepository;
        }

        public async Task<BaseCommandResponse<GetContactOutput>> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<GetContactOutput>();
            var validator = new UpdateContactCommandHandlerValidatior();
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
                var result = await _contactWriteRepository.UpdateAsync(contactMapp);
                var resultMapp = _mapper.Map<GetContactOutput>(result);

                response.Id = resultMapp.Id;
                response.Data = resultMapp;
                response.Success = true;
                response.Message = ContactMessages.UpdatedSuccess;
                response.Errors = null;
            }

            return response;
        }
    }
}