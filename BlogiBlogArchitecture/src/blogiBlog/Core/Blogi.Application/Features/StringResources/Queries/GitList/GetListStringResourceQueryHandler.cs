using Blogi.Application.Features.StringResources.Dtos.GitList;

namespace Blogi.Application.Features.StringResources.Queries.GitList
{
    public class GetListStringResourceQueryHandler : IRequestHandler<GetListStringResourceQuery, BaseCommandResponse<List<GetListStringResourceOutput>>>
    {
        private readonly IMapper _mapper;
        private readonly IStringResourceReadRepository _stringResourceReadRepository;

        public GetListStringResourceQueryHandler(IMapper mapper, IStringResourceReadRepository stringResourceReadRepository)
        {
            _mapper = mapper;
            _stringResourceReadRepository = stringResourceReadRepository;
        }

        public Task<BaseCommandResponse<List<GetListStringResourceOutput>>> Handle(GetListStringResourceQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
