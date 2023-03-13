using Blogi.Application.Features.Posts.Dtos.Get;

namespace Blogi.Application.Features.Posts.Queries.Get
{
    public class GetPostQueryHandler : IRequestHandler<GetPostQuery, BaseCommandResponse<GetPostOutput>>
    {
        private readonly IMapper _mapper;
        private readonly IPostReadRepository _postReadRepository;

        public GetPostQueryHandler(IMapper mapper, IPostReadRepository postReadRepository)
        {
            _mapper = mapper;
            _postReadRepository = postReadRepository;
        }

        public async Task<BaseCommandResponse<GetPostOutput>> Handle(GetPostQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<GetPostOutput>();
            var validator = new GetPostQueryHandlerValidatior(_postReadRepository);
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
                var result = await _postReadRepository.GetAsync(x => x.Id == request.Id);
                var resultMapp = _mapper.Map<GetPostOutput>(result);

                response.Id = resultMapp.Id;
                response.Data = resultMapp;
                response.Success = true;
                response.Message = PostMessages.GetByIdExists;
                response.Errors = null;
            }
            return response;
        }
    }
}