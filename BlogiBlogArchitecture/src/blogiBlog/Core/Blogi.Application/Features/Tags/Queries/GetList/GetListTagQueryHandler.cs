using Blogi.Application.Features.Tags.Dtos.Get;

namespace Blogi.Application.Features.Tags.Queries.GetList
{
    public class GetListTagQueryHandler : IRequestHandler<GetListTagQuery, BaseCommandResponse<List<GetTagOutput>>>
    {
        private readonly IMapper _mapper;
        private readonly ITagReadRepository _tagReadRepository;

        public GetListTagQueryHandler(IMapper mapper, ITagReadRepository tagReadRepository)
        {
            _mapper = mapper;
            _tagReadRepository = tagReadRepository;
        }

        public async Task<BaseCommandResponse<List<GetTagOutput>>> Handle(GetListTagQuery request, CancellationToken cancellationToken)
        {
            var response= new BaseCommandResponse<List<GetTagOutput>>();
            var result = await _tagReadRepository.GetListAsync();

            if (!result.Any())
            {
                response.Success = false;
                response.Message = TagMessages.GetListNotExists;
                response.Errors = null;
                response.Data = null;
            }
            else
            {
                var resultMapp = _mapper.Map<List<GetTagOutput>>(result);
                response.Data = resultMapp;
                response.Success = true;
                response.Message = TagMessages.GetListExists;
                response.Errors = null;
            }
            return response;
        }
    }
}
