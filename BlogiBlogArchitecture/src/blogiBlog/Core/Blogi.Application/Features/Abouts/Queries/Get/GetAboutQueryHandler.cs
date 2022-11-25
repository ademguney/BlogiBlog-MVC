using Blogi.Application.Features.Abouts.Dtos.Get;

namespace Blogi.Application.Features.Abouts.Queries.Get
{
    public class GetAboutQueryHandler : IRequestHandler<GetAboutQuery, BaseCommandResponse<GetAboutOutput>>
    {
        private readonly IMapper _mapper;
        private readonly IAboutReadRepository _aboutReadRepository;

        public GetAboutQueryHandler(IMapper mapper, IAboutReadRepository aboutReadRepository)
        {
            _mapper = mapper;
            _aboutReadRepository = aboutReadRepository;
        }

        public async Task<BaseCommandResponse<GetAboutOutput>> Handle(GetAboutQuery request, CancellationToken cancellationToken)
        {
            var response=new BaseCommandResponse<GetAboutOutput>();
            var result= await _aboutReadRepository.GetAll().FirstOrDefaultAsync();

            var resultMapp = _mapper.Map<GetAboutOutput>(result);
            response.Id = resultMapp.Id;
            response.Data = resultMapp;
            response.Success = true;
            response.Message = AboutMessages.GetByIdExists;
            response.Errors = null;

            return response;
        }
    }
}