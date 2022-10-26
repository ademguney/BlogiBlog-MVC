using Blogi.Application.Features.StringResources.Dtos.Get;

namespace Blogi.Application.Features.StringResources.Queries.Get
{
    public class GetStringResourceQueryHandler : IRequestHandler<GetStringResourceQuery, BaseCommandResponse<GetStringResourceOutput>>
    {
        private readonly IMapper _mapper;
        private readonly IStringResourceReadRepository _stringResourceReadRepository;

        public GetStringResourceQueryHandler(IMapper mapper, IStringResourceReadRepository stringResourceReadRepository)
        {
            _mapper = mapper;
            _stringResourceReadRepository = stringResourceReadRepository;
        }

        public async Task<BaseCommandResponse<GetStringResourceOutput>> Handle(GetStringResourceQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<GetStringResourceOutput>();
            var validator = new GetStringResourceQueryHandlerValidator(_stringResourceReadRepository);
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
                var result = await _stringResourceReadRepository.GetAsync(x => x.Id == request.Id);
                var resultMapp = _mapper.Map<GetStringResourceOutput>(result);

                response.Id = resultMapp.Id;
                response.Data = resultMapp;
                response.Success = true;
                response.Message = StringResourceMessages.GetListExists;
                response.Errors = null;
            }
            return response;
        }
    }
}
